﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XHTMLClassLibrary.BaseElements
{
    public enum TextStyles
    {
        Normal = 0,
        Strong, // <strong> , deprecated <b>
        Emphasis, // <em>
        Sub, // <sub>
        Sup, // <sup>
        Big, // <big>
        Small, // <small>
        StrikeOut, // <strike>
        Code, // <code>
    }



    /// <summary>
    /// Represent a simple HTML 5 text element (XText)
    /// </summary>
    /// "fake" Element name used here as it's never xElement but xText
    [HTMLItemAttribute(ElementName = "@__xText__@", SupportedStandards = HTMLElementType.HTML5 | HTMLElementType.XHTML5 | HTMLElementType.XHTML11 | HTMLElementType.Transitional | HTMLElementType.Strict | HTMLElementType.FrameSet)]
    public class SimpleHTML5Text : HTMLItem , ISimpleText
    {
        /// <summary>
        /// Textual data contained in element
        /// </summary>
        private string _text;

        public SimpleHTML5Text(HTMLElementType htmlStandard) : base(htmlStandard)
        {
        }

        /// <summary>
        /// Get/Set actual text contained in element
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value ?? string.Empty; }
        }

        /// <summary>
        /// Loads a text element from the HTML node
        /// </summary>
        /// <param name="xNode"></param>
        public override void Load(XNode xNode)
        {
            if (xNode.NodeType != XmlNodeType.Text)
            {
                throw new ArgumentException("xNode is not of text type", "xNode");
            }
            Text = ((XText)xNode).Value;
        }

        /// <summary>
        /// Creates a XText node from the contained text
        /// </summary>
        /// <returns></returns>
        public override XNode Generate()
        {
            return new XText(_text);
        }

        /// <summary>
        /// Check if element is valid
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            return (_text != null);
        }

        /// <summary>
        /// Adds sub item to the item , only if 
        /// allowed by the rules and element can accept content
        /// simple text can't have sub-items so it will always return false
        /// </summary>
        /// <param name="item">sub item to add</param>
        public override void Add(IHTMLItem item)
        {
            throw new Exception("This element does not contain or obtain sub items");
        }

        /// <summary>
        /// Remove "unlink" sub-item 
        /// useless here as can't have sub-items at all
        /// </summary>
        /// <param name="item"></param>
        public override void Remove(IHTMLItem item)
        {
            throw new Exception("This element does not contain or obtain sub items");
        }

        public override object Clone()
        {
            SimpleHTML5Text cloned = (SimpleHTML5Text)base.Clone();
            cloned.Text = Text;
            return cloned;
        }

        /// <summary>
        /// Return list of sub-items,
        /// useless here as can not contain sub-items
        /// </summary>
        /// <returns></returns>
        public override List<IHTMLItem> SubElements()
        {
            return null;
        }

    }
}
