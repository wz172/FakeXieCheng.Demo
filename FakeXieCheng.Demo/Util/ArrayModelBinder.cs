using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Util
{
    public class ArrayModelBinder : IModelBinder
    {
        private string[] splitStrArr = new string[] { ",", "，" };

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //1. 判断数据类型
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            //2.获取输入参数字符串
            string inputStrValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();
            if (string.IsNullOrEmpty(inputStrValue))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            //3. 数据转换类型的获取

            //3.1参数类型
            var elementType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments.FirstOrDefault();
            if (elementType==null)
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }
            //3.2 根据参数类型，转化类型获取
            var elementConverter = TypeDescriptor.GetConverter(elementType);

            //4. 开始转化数据
            var values = inputStrValue.Split(splitStrArr, StringSplitOptions.RemoveEmptyEntries)
                .Select(xt => elementConverter.ConvertFromString(xt.Trim())).ToArray();

            //5. 未解操作
            var typedValues = Array.CreateInstance(elementType, values.Length);
            values.CopyTo(typedValues, 0);

            //6.绑定数据 返回结果
            bindingContext.Model = typedValues;
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
