﻿using XHTMLClassLibrary.AttributeDataTypes;
using XHTMLClassLibrary.Attributes;


namespace XHTMLClassLibrary.BaseElements.Structure_Header
{
    /// <summary>
    /// To resolve relative URLs, Web browsers will use the base URL from where the Web page was downloaded. 
    /// In some circumstances, it is necessary to instruct the Web browser to use a different base URL, 
    /// in which case the base element is used.
    /// </summary>
    [HTMLItemAttribute(ElementName = "base", SupportedStandards = HTMLElementType.HTML5 |  HTMLElementType.XHTML5 | HTMLElementType.XHTML11 | HTMLElementType.Transitional | HTMLElementType.Strict | HTMLElementType.FrameSet)]
    public class Base : HTMLItem
    {
        [AttributeTypeAttributeMember(SupportedStandards = HTMLElementType.HTML5 | HTMLElementType.XHTML5 | HTMLElementType.XHTML11 | HTMLElementType.Transitional | HTMLElementType.Strict | HTMLElementType.FrameSet)]
        private readonly SimpleSingleTypeAttribute<URI> _hrefAttribute = new SimpleSingleTypeAttribute<URI>("href");

        [AttributeTypeAttributeMember(SupportedStandards = HTMLElementType.HTML5 | HTMLElementType.XHTML5 | HTMLElementType.XHTML11 | HTMLElementType.Transitional | HTMLElementType.Strict | HTMLElementType.FrameSet)]
        private readonly SimpleSingleTypeAttribute<TargetType> _targetAttribute = new SimpleSingleTypeAttribute<TargetType>("target");


        public Base(HTMLElementType htmlStandard) : base(htmlStandard)
        {
        }

        /// <summary>
        /// Specifies the base URL for all relative URLs in the page
        /// </summary>
        public IAttributeDataAccess HRef { get { return _hrefAttribute; } }

        /// <summary>
        /// Specifies the default target for all hyperlinks and forms in the page
        /// </summary>
        public IAttributeDataAccess Target { get { return _targetAttribute; }}
        

        public override bool IsValid()
        {
            return true;
        }

    }
}
