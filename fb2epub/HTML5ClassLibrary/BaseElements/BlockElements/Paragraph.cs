﻿using System.ComponentModel;
using XHTMLClassLibrary.AttributeDataTypes;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.InlineElements;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    /// <summary>
    /// The p element represents a paragraph.
    /// </summary>
    [HTMLItemAttribute(ElementName = "p", SupportedStandards = HTMLElementType.HTML5 |  HTMLElementType.XHTML5 | HTMLElementType.Transitional | HTMLElementType.Strict | HTMLElementType.FrameSet | HTMLElementType.XHTML11)]
    public class Paragraph : HTMLItem, IBlockElement
    {

        #region Attribute_Values_Enums

        /// <summary>
        /// "align" attribute possible values
        /// </summary>
        public enum AlignAttributeOptions
        {
            [Description("center")]
            Center,

            [Description("char")]
            Char,

            [Description("justify")]
            Justify,

            [Description("left")]
            Left,

            [Description("right")]
            Right,
        }

        #endregion


        [AttributeTypeAttributeMember(SupportedStandards = HTMLElementType.XHTML11 | HTMLElementType.Transitional | HTMLElementType.Strict | HTMLElementType.FrameSet)]
        private readonly ValuesSelectionTypeAttribute<Text> _alignAttribute = new ValuesSelectionTypeAttribute<Text>("align",typeof(AlignAttributeOptions));


        public Paragraph(HTMLElementType htmlStandard) : base(htmlStandard)
        {
        }

        /// <summary>
        ///  Specifies the alignment of the text within a paragraph
        /// Not supported in HTML5.
        /// </summary>
        public IAttributeDataAccess Align { get { return _alignAttribute; } }

        protected override bool IsValidSubType(IHTMLItem item)
        {
            if (item is IInlineItem)
            {
                return item.IsValid();
            }
            if (item is SimpleHTML5Text)
            {
                return item.IsValid();
            }
            return false;
        }


        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        public override bool IsValid()
        {
            return true;
        }

    }
}