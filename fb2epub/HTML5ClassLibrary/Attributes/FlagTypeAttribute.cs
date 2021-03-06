﻿using System;
using System.Xml.Linq;
using XHTMLClassLibrary.BaseElements;

namespace XHTMLClassLibrary.Attributes
{
    public class FlagTypeAttribute : BaseAttribute
    {
        private readonly bool _putValue;


        public FlagTypeAttribute(string name, bool putNameAsValue)
            : base(name)
        {
            _putValue = putNameAsValue;
        }

        public FlagTypeAttribute(string name)
            : base(name)
        {
            _putValue = false;
        }

        public override void AddAttribute(XElement xElement, XNamespace ns)
        {
            if (!AttributeHasValue)
            {
                return;
            }
            xElement.Add(ns != null
                ? new XAttribute(ns + GetAttributeName(), _putValue ? GetAttributeName() : string.Empty)
                : new XAttribute(GetAttributeName(), _putValue ? GetAttributeName() : string.Empty));
        }

        public override void ReadAttribute(XElement element)
        {
            AttributeHasValue = false;
            XAttribute xObject = element.Attribute(GetAttributeName());
            if (xObject != null)
            {
                AttributeHasValue = true;
            }
        }

        public override object Value
        {
            get
            {
                if (!AttributeHasValue)
                {
                    return null;
                }
                return GetAttributeName();
            }
            set
            {
                AttributeHasValue = false;
                if ( !(value is bool) && !(value is string))
                    return;
                if (value is bool)
                {
                    AttributeHasValue = (bool)value;
                    return;
                }
                if (string.Compare((value as string), GetAttributeName(), StringComparison.Ordinal) == 0)
                {
                    AttributeHasValue = true;
                }
                else
                {
                    bool hasValue;
                    if (bool.TryParse(value as string, out hasValue))
                    {
                        AttributeHasValue = hasValue;
                    }
                }
            }
        }
    }
}