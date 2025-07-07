using System;

namespace GeekTrust
{
    public enum PassengerType
    {
        [Fare(200)]
        ADULT,
        [Fare(100)]
        SENIOR_CITIZEN,
        [Fare(50)]
        KID
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class FareAttribute : Attribute
    {
        public int Value { get; }
        public FareAttribute(int value) => Value = value;
    }
}