﻿using XHTMLClassLibrary.AttributeDataTypes;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.InlineElements;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    /// <summary>
    /// The "canvas" tag is used to draw graphics, on the fly, via scripting (usually JavaScript).
    /// The "canvas" tag is only a container for graphics, you must use a script to actually draw the graphics.
    /// </summary>
    [HTMLItemAttribute(ElementName = "canvas", SupportedStandards = HTMLElementType.HTML5)]
    public class Canvas : HTMLItem, IBlockElement
    {
        [AttributeTypeAttributeMember(SupportedStandards = HTMLElementType.HTML5 | HTMLElementType.XHTML5)]
        private readonly SimpleSingleTypeAttribute<Length> _height = new SimpleSingleTypeAttribute<Length>("height");

        [AttributeTypeAttributeMember(SupportedStandards = HTMLElementType.HTML5 | HTMLElementType.XHTML5)]
        private readonly SimpleSingleTypeAttribute<Length> _width = new SimpleSingleTypeAttribute<Length>("width");


        public Canvas(HTMLElementType htmlStandard) : base(htmlStandard)
        {
        }

        public IAttributeDataAccess Height
        {
            get { return _height; }
        }

        public IAttributeDataAccess Width
        {
            get { return _width; }
        }

        public override bool IsValid()
        {
            return true;
        }

        protected override bool IsValidSubType(IHTMLItem item)
        {
            if (item is IInlineItem ||
                item is IBlockElement ||
                item is SimpleHTML5Text)
            {
                return item.IsValid();
            }
            return false;
        }

    }
}
