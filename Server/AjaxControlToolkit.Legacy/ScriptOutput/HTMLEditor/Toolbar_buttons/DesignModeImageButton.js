Type.registerNamespace("Sys.Extended.UI.HTMLEditor.ToolbarButton");Sys.Extended.UI.HTMLEditor.ToolbarButton.DesignModeImageButton=function(a){Sys.Extended.UI.HTMLEditor.ToolbarButton.DesignModeImageButton.initializeBase(this,[a]);this._designPanel=null};Sys.Extended.UI.HTMLEditor.ToolbarButton.DesignModeImageButton.prototype={_onmousedown:function(c){var a=false,b=this;if(b._designPanel==null)return a;if(b._designPanel.isPopup())return a;if(Sys.Extended.UI.HTMLEditor.ToolbarButton.DesignModeImageButton.callBaseMethod(b,"_onmousedown",[c])===null)return a;b.callMethod();return a},onEditPanelActivity:function(){this._designPanel=this._editPanel.get_activePanel()},callMethod:function(){return this._designPanel==null?false:this._designPanel.isPopup()?false:true}};Sys.Extended.UI.HTMLEditor.ToolbarButton.DesignModeImageButton.registerClass("Sys.Extended.UI.HTMLEditor.ToolbarButton.DesignModeImageButton",Sys.Extended.UI.HTMLEditor.ToolbarButton.ImageButton);