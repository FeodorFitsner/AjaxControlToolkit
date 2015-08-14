using System;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using AjaxControlToolkit.Design;

namespace AjaxControlToolkit {

    [Designer(typeof(SlideShowExtenderDesigner))]
    [ClientScriptResource("Sys.Extended.UI.SlideShowBehavior", Constants.SlideShowName)]
    [ClientCssResource(Constants.SlideShowName)]
    [TargetControlType(typeof(System.Web.UI.WebControls.Image))]
    [RequiredScript(typeof(CommonToolkitScripts))]
    [RequiredScript(typeof(TimerScript))]
    [ToolboxBitmap(typeof(ToolboxIcons.Accessor), Constants.SlideShowName + Constants.IconPostfix)]
    public class SlideShowExtender : ExtenderControlBase {
        /// <summary>
        /// The webservice method that will be called to supply images.
        /// </summary>
        [ExtenderControlProperty]
        [RequiredProperty]
        [DefaultValue("")]
        [ClientPropertyName("slideShowServiceMethod")]
        public string SlideShowServiceMethod {
            get { return GetPropertyValue("SlideShowServiceMethod", String.Empty); }
            set { SetPropertyValue("SlideShowServiceMethod", value); }
        }

        /// <summary>
        /// Path to the webservice that the extender will pull the images from.
        /// </summary>
        [UrlProperty()]
        [ExtenderControlProperty()]
        [TypeConverter(typeof(ServicePathConverter))]
        [ClientPropertyName("slideShowServicePath")]
        public string SlideShowServicePath {
            get { return GetPropertyValue("SlideShowServicePath", String.Empty); }
            set { SetPropertyValue("SlideShowServicePath", value); }
        }

        /// <summary>
        /// User/page specific context provided to an optional overload of the
        /// web method described by ServiceMethod/ServicePath.
        /// </summary>
        /// <remarks>
        /// If the context key is used, it should have the same signature
        /// with an additional parameter named contextKey of type string.
        /// </remarks>
        [ExtenderControlProperty]
        [ClientPropertyName("contextKey")]
        [DefaultValue(null)]
        public string ContextKey {
            get { return GetPropertyValue<string>("ContextKey", null); }
            set {
                SetPropertyValue<string>("ContextKey", value);
                UseContextKey = true;
            }
        }

        /// <summary>
        /// Whether or not the ContextKey property should be used.
        /// </summary>
        /// <remarks>
        /// This will be automatically enabled if the ContextKey property is ever set
        /// (on either the client or the server). If the context key is used,
        /// it should have the same signature with an additional parameter
        /// named contextKey of type string.
        /// </remarks>
        [ExtenderControlProperty]
        [ClientPropertyName("useContextKey")]
        [DefaultValue(false)]
        public bool UseContextKey {
            get { return GetPropertyValue<bool>("UseContextKey", false); }
            set { SetPropertyValue<bool>("UseContextKey", value); }
        }

        /// <summary>
        /// ID of the control that will move the slide show to the next slide.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(WebControl))]
        [ClientPropertyName("nextButtonID")]
        public string NextButtonID {
            get { return GetPropertyValue("NextButtonID", String.Empty); }
            set { SetPropertyValue("NextButtonID", value); }
        }

        /// <summary>
        /// ID of the control that will play the slide show.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(WebControl))]
        [ClientPropertyName("playButtonID")]
        public string PlayButtonID {
            get { return GetPropertyValue("PlayButtonID", String.Empty); }
            set { SetPropertyValue("PlayButtonID", value); }
        }

        /// <summary>
        /// Text to display in the play button if the slide show is not playing.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [ClientPropertyName("playButtonText")]
        public string PlayButtonText {
            get { return GetPropertyValue("PlayButtonText", String.Empty); }
            set { SetPropertyValue("PlayButtonText", value); }
        }

        /// <summary>
        /// Text to display in the play button if the slide show is in play mode.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [ClientPropertyName("stopButtonText")]
        public string StopButtonText {
            get { return GetPropertyValue("StopButtonText", String.Empty); }
            set { SetPropertyValue("StopButtonText", value); }
        }

        /// <summary>
        /// Interval in milliseconds before switching to the next slide is playing. 
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue(3000)]
        [ClientPropertyName("playInterval")]
        public int PlayInterval {
            get { return GetPropertyValue("PlayInterval", 3000); }
            set { SetPropertyValue("PlayInterval", value); }
        }

        /// <summary>
        /// ID of the label that will display the current slide's title.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(WebControl))]
        [ClientPropertyName("imageTitleLabelID")]
        public string ImageTitleLabelID {
            get { return GetPropertyValue("ImageTitleLabelID", String.Empty); }
            set { SetPropertyValue("ImageTitleLabelID", value); }
        }

        /// <summary>
        /// ID of the label that will display the current slide's description.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(WebControl))]
        [ClientPropertyName("imageDescriptionLabelID")]
        public string ImageDescriptionLabelID {
            get { return GetPropertyValue("ImageDescriptionLabelID", String.Empty); }
            set { SetPropertyValue("ImageDescriptionLabelID", value); }
        }

        /// <summary>
        /// ID of the control that will move the slide show to the previous slide.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(WebControl))]
        [ClientPropertyName("previousButtonID")]
        public string PreviousButtonID {
            get { return GetPropertyValue("PreviousButtonID", String.Empty); }
            set { SetPropertyValue("PreviousButtonID", value); }
        }

        /// <summary>
        /// Boolean to determine if the slide show loops around if you hit the first or last slide.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue(false)]
        [ClientPropertyName("loop")]
        public bool Loop {
            get { return GetPropertyValue("Loop", false); }
            set { SetPropertyValue("Loop", value); }
        }

        /// <summary>
        /// Boolean to determine if the slide show will play automatically on render.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue(false)]
        [ClientPropertyName("autoPlay")]
        public bool AutoPlay {
            get { return GetPropertyValue("AutoPlay", false); }
            set { SetPropertyValue("AutoPlay", value); }
        }

        /// <summary>
        /// Animation type that will happen on change of slide.
        /// </summary>
        /// <remarks>
        /// If you set SlideShowAnimationType to either SlideDown or SlideRight
        /// then you must set both the Height and Width properties on the Image
        /// control being extended by the SlideShow extender.
        /// </remarks>
        [ExtenderControlProperty]
        [DefaultValue(SlideShowAnimationType.None)]
        [ClientPropertyName("slideShowAnimationType")]
        public SlideShowAnimationType SlideShowAnimationType {
            get { return GetPropertyValue("SlideShowAnimationType", SlideShowAnimationType.None); }
            set { SetPropertyValue("SlideShowAnimationType", value); }
        }

        /// <summary>
        /// Width of the image container to animate slides smoothly from left to right or right to left.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue(400)]
        [Browsable(false)]
        [ClientPropertyName("imageWidth")]
        public int ImageWidth {
            get { return GetPropertyValue("ImageWidth", 400); }
            set { SetPropertyValue("ImageWidth", value); }
        }

        /// <summary>
        /// Height of the image container to animate slides smoothly from up to down or down to up.
        /// </summary>
        [ExtenderControlProperty]
        [DefaultValue(300)]
        [Browsable(false)]
        [ClientPropertyName("imageHeight")]
        public int ImageHeight {
            get { return GetPropertyValue("ImageHeight", 300); }
            set { SetPropertyValue("ImageHeight", value); }
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);

            var image = (System.Web.UI.WebControls.Image)TargetControl;
            ImageHeight = (int)image.Height.Value;
            ImageWidth = (int)image.Width.Value;
        }
    }

}
