using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Stateless;

namespace FakeXieCheng.Demo.Models
{

    public enum OrderStateEnum
    { 
        Generateing,//订单创建
        paying,//订单支付中
        PayError,//订单支付失败
        CompleatePay,//订单完成支付
        CancleOrder,//订单取消支付
        Refund,//退款
    }

    public enum OrderStateTriggerEnum
    { 
        PlayOrederAction,//支付订单
        PlayOkAction,//支付成功
        PlayErrorAction,//支付失败
        CancleAction,//取消支付
        ReturnAction,//退货
    }
    public class UserOrder
    {
        [Key]
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public MyApplicationIdentity User { get; set; }
        public IEnumerable<CartLineItem> UserOrderCartItems { get; set; }
        public DateTime CreateTimeUtc { get; set; }
        public OrderStateEnum OrderState { get; set; }
        public string ThirdPartyPayMent{ get; set; }

        readonly StateMachine<OrderStateEnum, OrderStateTriggerEnum> machine;
        public UserOrder()
        {
            machine = new StateMachine<OrderStateEnum, OrderStateTriggerEnum>(OrderStateEnum.Generateing);

            machine.Configure(OrderStateEnum.Generateing)
                .Permit(OrderStateTriggerEnum.PlayOrederAction, OrderStateEnum.paying)
                .Permit(OrderStateTriggerEnum.CancleAction,OrderStateEnum.CancleOrder);

            machine.Configure(OrderStateEnum.paying)
                .Permit(OrderStateTriggerEnum.PlayOkAction, OrderStateEnum.CompleatePay)
                .Permit(OrderStateTriggerEnum.PlayErrorAction, OrderStateEnum.PayError);

            machine.Configure(OrderStateEnum.PayError)
                .Permit(OrderStateTriggerEnum.PlayOrederAction, OrderStateEnum.CompleatePay);

            machine.Configure(OrderStateEnum.CompleatePay)
                .Permit(OrderStateTriggerEnum.ReturnAction, OrderStateEnum.Refund);

        }
    }
}
