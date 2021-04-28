using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.RequestParams
{
    public class TouristRouteRequestParam
    {
        public string TitleKeyWord { get; set; }
        public float? RatingValue { get; set; }
        public LogicType RatingLogicType { get; set; } = LogicType.Null;
        private string rating;
        public string Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                Regex regex = new Regex(@"([a-zA-z]+)([0-9]+)");
                if (regex.IsMatch(rating))
                {
                    var groups = regex.Matches(rating);
                    Type logicAssemblyType = typeof(LogicType);
                    float ratingFVal = float.MinValue;
                    foreach (FieldInfo field in logicAssemblyType.GetFields())
                    {
                        if (field.Name.ToLower() == groups[0].Groups[1].Value.ToLower())
                        {
                            RatingLogicType = (LogicType)field.GetValue(null);
                            float.TryParse(groups[0].Groups[2].Value, out ratingFVal);
                            break;
                        }
                    }
                    if (ratingFVal != float.MinValue)
                    {
                        RatingValue = ratingFVal;
                    }
                    else
                    {
                        RatingLogicType = LogicType.Null;
                    }
                }
            }
        }
    }

    public enum LogicType
    {
        Null,
        LessThen,
        EqualTo,
        LargeThen,
        LessAndEqual,
        LargeAndEqual,
    }

 
}
