using System;

namespace MyOption
{
    public static class Option
    {
        public static Option<T> Some<T>(T value) => Option<T>.Some(value);

        public static Option<T> None<T>() => Option<T>.None;
    
    }

    public abstract class Option<T>
    {

        public static readonly Option<T> None = new None<T>();

//        public static Option<T> None() => _none;

        public abstract T Value { get; }

        public abstract bool IsNone { get; }

        public abstract Option<TRes> Map<TRes>(Func<T,TRes> func);

        public static Option<T> Flatten(Option<Option<T>> opt) => opt.IsNone ? Option<T>.None : opt.Value;

        public bool IsSome => !IsNone;

        public static Option<T> Some(T value) => new Some<T> (value);

    }

    public class Some<T> : Option<T>
    {
        private readonly T _value;

        public override T Value => _value;

        public override bool IsNone => false;

        public Some(T value)
        {
            if (value == null)
                throw new NullValueException("null value in Same");

            _value = value;
        }

        public override Option<TRes> Map<TRes>(Func<T, TRes> func) => new Some<TRes>(func(_value));
		
    }

    public class None<T> : Option<T>
    {
        public override T Value
        {
            get { throw new NotValueException("not value; is None"); }
        }

        public override bool IsNone => true;

        public override Option<TRes> Map<TRes>(Func<T, TRes> func) => Option<TRes>.None;

    }
}

