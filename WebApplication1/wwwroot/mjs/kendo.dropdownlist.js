/**
 * Kendo UI v2023.2.718 (http://www.telerik.com/kendo-ui)
 * Copyright 2023 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.list.js";import"./kendo.mobile.scroller.js";import"./kendo.virtuallist.js";import"./kendo.html.button.js";import"./kendo.icons.js";var __meta__={id:"dropdownlist",name:"DropDownList",category:"web",description:"The DropDownList widget displays a list of values and allows the selection of a single value from the list.",depends:["list","html.button","icons"],features:[{id:"mobile-scroller",name:"Mobile scroller",description:"Support for kinetic scrolling in mobile device",depends:["mobile.scroller"]},{id:"virtualization",name:"VirtualList",description:"Support for virtualization",depends:["virtuallist"]}]};!function(e,t){var i=window.kendo,n=i.htmlEncode,o=i.ui,s=i.html,a=o.List,l=o.Select,r=i.support,p=i._activeElement,u=i.data.ObservableObject,c=i.keys,d=".kendoDropDownList",f=d+"FocusEvent",_="disabled",h="readonly",m="change",v="k-focus",b="k-disabled",w="aria-disabled",g="aria-readonly",I="mouseenter"+d+" mouseleave"+d,L="tabindex",x="filter",k="accept",y=l.extend({init:function(n,o){var s,a,r=this,p=o&&o.index;r.ns=d,o=Array.isArray(o)?{dataSource:o}:o,l.fn.init.call(r,n,o),o=r.options,n=r.element.on("focus"+d,r._focusHandler.bind(r)),r._focusInputHandler=r._focusInput.bind(r),r.optionLabel=e(),r._optionLabel(),r._inputTemplate(),r._reset(),r._prev="",r._word="",r._wrapper(),r._tabindex(),r.wrapper.data(L,r.wrapper.attr(L)),r._span(),r._popup(),r._mobile(),r._dataSource(),r._ignoreCase(),o.label&&this._label(),r._aria(),r._enable(),r._oldIndex=r.selectedIndex=-1,p!==t&&(o.index=p),r._initialIndex=o.index,r.requireValueMapper(r.options),r._initList(),r.listView.one("dataBound",r._attachAriaActiveDescendant.bind(r)),r._cascade(),r.one("set",(function(e){!e.sender.listView.bound()&&r.hasOptionLabel()&&r._textAccessor(r._optionLabelText())})),o.autoBind?r.dataSource.fetch():-1===r.selectedIndex&&((a=o.text||"")||((s=o.optionLabel)&&0===o.index?a=s:r._isSelect&&(a=n.children(":selected").text())),r._textAccessor(a)),e(r.element).parents("fieldset").is(":disabled")&&r.enable(!1),r.listView.bind("click",(function(e){e.preventDefault()})),i.notify(r),r._applyCssClasses()},options:{name:"DropDownList",enabled:!0,autoBind:!0,index:0,text:null,value:null,delay:500,height:200,dataTextField:"",dataValueField:"",optionLabel:"",cascadeFrom:"",cascadeFromField:"",cascadeFromParentField:"",ignoreCase:!0,animation:{},filter:"none",minLength:1,enforceMinLength:!1,virtual:!1,template:null,valueTemplate:null,optionLabelTemplate:null,groupTemplate:e=>n(e),fixedGroupTemplate:e=>n(e),autoWidth:!1,popup:null,filterTitle:null,size:"medium",fillMode:"solid",rounded:"medium",label:null,popupFilter:!0},events:["open","close",m,"select","filtering","dataBinding","dataBound","cascade","set","kendoKeydown"],setOptions:function(e){l.fn.setOptions.call(this,e),this.listView.setOptions(this._listOptions(e)),this._optionLabel(),this._inputTemplate(),this._accessors(),this._removeFilterHeader(),this._addFilterHeader(),this._enable(),this._aria(),!this.value()&&this.hasOptionLabel()&&this.select(0)},destroy:function(){var e=this;l.fn.destroy.call(e),e.wrapper.off(d),e.wrapper.off(f),e.element.off(d),e._arrow.off(),e._arrow=null,e._arrowIcon=null,e.optionLabel.off(),e.filterInput&&e.filterInput.off(f)},open:function(){var e=this,t=!!e.dataSource.filter()&&e.dataSource.filter().filters.length>0,i=this.listView;e.popup.visible()||(e.listView.bound()&&e._state!==k?e._allowOpening()&&(e._focusFilter=!0,e.popup.one("activate",e._focusInputHandler),e.popup._hovered=!0,e.wrapper.attr("aria-activedescendant",i._optionID),e.popup.open(),e._resizeFilterInput(),e._focusItem()):(e._open=!0,e._state="rebind",e.filterInput&&(e.filterInput.val(""),e._prev=""),e.filterInput&&1!==e.options.minLength&&!t?(e.refresh(),e.popup.one("activate",e._focusInputHandler),e.wrapper.attr("aria-activedescendant",i._optionID),e.popup.open(),e._resizeFilterInput()):e._filterSource()))},close:function(){this._attachAriaActiveDescendant(),this.popup.close()},_attachAriaActiveDescendant:function(){var e=this.wrapper,t=e.find(".k-input-inner").attr("id");e.attr("aria-describedby",t)},_focusInput:function(){this._hasActionSheet()||this._focusElement(this.filterInput)},_resizeFilterInput:function(){var e=this.filterInput,t=this._prevent;if(e&&!this._hasActionSheet()){var n=this.filterInput[0]===p(),o=i.caret(this.filterInput[0])[0];this._prevent=!0,e.addClass("k-hidden"),e.closest(".k-list-filter").css("width",this.popup.element.width()),e.removeClass("k-hidden"),n&&(e.trigger("focus"),i.caret(e[0],o)),this._prevent=t}},_allowOpening:function(){return this.hasOptionLabel()||this.filterInput||l.fn._allowOpening.call(this)},toggle:function(e){this._toggle(e,!0)},current:function(e){var i;if(e===t)return!(i=this.listView.focus())&&0===this.selectedIndex&&this.hasOptionLabel()?this.optionLabel:i;this._focus(e)},dataItem:function(i){var n=this,o=null;if(null===i)return i;if(i===t)o=n.listView.selectedDataItems()[0];else{if("number"!=typeof i){if(n.options.virtual)return n.dataSource.getByUid(e(i).data("uid"));i=i.hasClass("k-list-optionlabel")?-1:e(n.items()).index(i)}else n.hasOptionLabel()&&(i-=1);o=n.dataSource.flatView()[i]}return o||(o=n._optionLabelDataItem()),o},refresh:function(){this.listView.refresh()},text:function(e){var i,n=this,o=n.options.ignoreCase;if((e=null===e?"":e)===t)return n._textAccessor();"string"==typeof e?(i=o?e.toLowerCase():e,n._select((function(e){return e=n._text(e),o&&(e=(e+"").toLowerCase()),e===i})).done((function(){n._textAccessor(n.dataItem()||e),n._refreshFloatingLabel()}))):n._textAccessor(e)},_clearFilter:function(){e(this.filterInput).val(""),l.fn._clearFilter.call(this)},value:function(e){var i=this,n=i.listView,o=i.dataSource;return e===t?(e=i._accessor()||i.listView.value()[0])===t||null===e?"":e:(i.requireValueMapper(i.options,e),!e&&i.hasOptionLabel()||(i._initialIndex=null),this.trigger("set",{value:e}),i._request&&i.options.cascadeFrom&&i.listView.bound()?(i._valueSetter&&o.unbind(m,i._valueSetter),i._valueSetter=function(){i.value(e)}.bind(i),void o.one(m,i._valueSetter)):(i._isFilterEnabled()&&n.bound()&&n.isFiltered()?i._clearFilter():i._fetchData(),void n.value(e).done((function(){i._old=i._valueBeforeCascade=i._accessor(),i._oldIndex=i.selectedIndex,i._refreshFloatingLabel()}))))},hasOptionLabel:function(){return this.optionLabel&&!!this.optionLabel[0]},_optionLabel:function(){var t=this,o=t.options,s=o.optionLabel,a=o.optionLabelTemplate;if(!s)return t.optionLabel.off().remove(),void(t.optionLabel=e());a||(a=e=>n("string"==typeof s?e:i.getter(o.dataTextField)(e))),"function"!=typeof a&&(a=i.template(a)),t.optionLabelTemplate=a,t.hasOptionLabel()||(t.optionLabel=e('<div role="option" class="k-list-optionlabel"></div>').prependTo(t.list)),t.optionLabel.html(a(s)).off().on("click.kendoDropDownList touchend.kendoDropDownList",t._click.bind(t)).on(I,t._toggleHover),t.angular("compile",(function(){return{elements:t.optionLabel,data:[{dataItem:t._optionLabelDataItem()}]}}))},_optionLabelText:function(){var e=this.options.optionLabel;return"string"==typeof e?e:this._text(e)},_optionLabelDataItem:function(){var i=this,n=i.options.optionLabel;return i.hasOptionLabel()?e.isPlainObject(n)?new u(n):i._assignInstance(i._optionLabelText(),""):t},_buildOptions:function(e){var i=this;if(i._isSelect){var n=i.listView.value()[0],o=i._optionLabelDataItem(),s=o&&i._value(o);n!==t&&null!==n||(n=""),o&&(s!==t&&null!==s||(s=""),o='<option value="'+s+'">'+i._text(o)+"</option>"),i._options(e,o,n),n!==a.unifyType(i._accessor(),typeof n)&&(i._customOption=null,i._custom(n))}},_listBound:function(){var e,t=this,i=t._initialIndex,n=t._state===x,o=t.dataSource.flatView();t._presetValue=!1,t._renderFooter(),t._renderNoData(),t._toggleNoData(!o.length),t._resizePopup(!0),t.popup.position(),t._buildOptions(o),n||(t._open&&t.toggle(t._allowOpening()),t._open=!1,t._fetch||(o.length?(!t.listView.value().length&&i>-1&&null!==i&&t.select(i),t._initialIndex=null,(e=t.listView.selectedDataItems()[0])&&t.text()!==t._text(e)&&t._selectValue(e)):t._textAccessor()!==t._optionLabelText()&&(t.listView.value(""),t._selectValue(null),t._oldIndex=t.selectedIndex))),t._hideBusy(),t.trigger("dataBound")},_listChange:function(){this._selectValue(this.listView.selectedDataItems()[0]),(this._presetValue||this._old&&-1===this._oldIndex)&&(this._oldIndex=this.selectedIndex)},_filterPaste:function(){this._search()},_attachFocusHandlers:function(){var e=this;e.wrapper.on("focusin"+f,e._focusinHandler.bind(e)).on("focusout"+f,e._focusoutHandler.bind(e)),e.filterInput&&e.filterInput.on("focusin"+f,e._focusinHandler.bind(e)).on("focusout"+f,e._focusoutHandler.bind(e))},_focusHandler:function(){this.wrapper.trigger("focus")},_focusinHandler:function(){this.wrapper.addClass(v),this._prevent=!1},_focusoutHandler:function(){var e=this,t=window.self!==window.top;e._prevent||(clearTimeout(e._typingTimeout),r.mobileOS.ios&&t?e._change():e._blur(),e.wrapper.removeClass(v),e._prevent=!0,e._open=!1,e.element.trigger("blur"))},_wrapperMousedown:function(){this._prevent=!!this.filterInput},_wrapperClick:function(e){e.preventDefault(),this.popup.unbind("activate",this._focusInputHandler),this._focused=this.wrapper,this._prevent=!1,this._toggle()},_editable:function(e){var t=this,n=t.element,o=e.disable,s=e.readonly,a=t.wrapper.add(t.filterInput).off(d),l=t.wrapper.off(I);s||o?o?(a.removeAttr(L),l.addClass(b)):l.removeClass(b):(n.prop(_,!1).prop(h,!1),l.removeClass(b).on(I,t._toggleHover),a.attr(L,a.data(L)).attr(w,!1).attr(g,!1).on("keydown"+d,t,t._keydown.bind(t)).on(i.support.mousedown+d,t._wrapperMousedown.bind(t)).on("paste"+d,t._filterPaste.bind(t)),t.wrapper.on("click"+d,t._wrapperClick.bind(t)),t.filterInput?a.on("input"+d,t._search.bind(t)):a.on("keypress"+d,t._keypress.bind(t))),n.attr(_,o).attr(h,s),a.attr(w,o).attr(g,s)},_keydown:function(e){var t,i,n=this,o=e.keyCode,s=e.altKey,a=n.popup.visible();if(n.filterInput&&(t=n.filterInput[0]===p()),o===c.LEFT?(o=c.UP,i=!0):o===c.RIGHT&&(o=c.DOWN,i=!0),!i||!t)if(e.keyCode=o,(s&&o===c.UP||o===c.ESC)&&n._focusElement(n.wrapper),n._state===x&&o===c.ESC&&(n._clearFilter(),n._open=!1,n._state=k),o===c.ENTER&&n._typingTimeout&&n.filterInput&&a)e.preventDefault();else if(o!==c.SPACEBAR||t||(n.toggle(!a),e.preventDefault()),!(i=n._move(e))){if(!a||!n.filterInput){var l=n._focus();if(o===c.HOME?(i=!0,n._firstItem()):o===c.END&&(i=!0,n._lastItem()),i){if(n.trigger("select",{dataItem:n._getElementDataItem(n._focus()),item:n._focus()}))return void n._focus(l);n._select(n._focus(),!0).done((function(){a||n._blur()})),e.preventDefault()}}s||i||!n.filterInput||n._search()}},_matchText:function(e,i){var n=this.options.ignoreCase;return e!==t&&null!==e&&(e+="",n&&(e=e.toLowerCase()),0===e.indexOf(i))},_shuffleData:function(e,t){var i=this._optionLabelDataItem();return i&&(e=[i].concat(e)),e.slice(t).concat(e.slice(0,t))},_selectNext:function(){var e,t,i=this,n=i.dataSource.flatView(),o=n.length+(i.hasOptionLabel()?1:0),s=function(e,t){for(var i=0;i<e.length;i++)if(e.charAt(i)!==t)return!1;return!0}(i._word,i._last),a=i.selectedIndex;a=-1===a?0:D(a+=s?1:0,o),n=n.toJSON?n.toJSON():n.slice(),n=i._shuffleData(n,a);for(var l=0;l<o&&(t=i._text(n[l]),!s||!i._matchText(t,i._last))&&!i._matchText(t,i._word);l++);l!==o&&(e=i._focus(),i._select(D(a+l,o)).done((function(){var t=function(){i.popup.visible()||i._change()};i.trigger("select",{dataItem:i._getElementDataItem(i._focus()),item:i._focus()})?i._select(e).done(t):t()})))},_keypress:function(e){var t=this;if(0!==e.which&&e.keyCode!==i.keys.ENTER){var n=String.fromCharCode(e.charCode||e.keyCode);t.options.ignoreCase&&(n=n.toLowerCase())," "===n&&e.preventDefault(),t._word+=n,t._last=n,t._search()}},_popupOpen:function(e){var t=this.popup;e.isDefaultPrevented()||this._hasActionSheet()||(t.wrapper=i.wrap(t.element),t.element.closest(".km-root")[0]&&(t.wrapper.addClass("km-popup km-widget"),this.wrapper.addClass("km-widget")))},_popup:function(){l.fn._popup.call(this),this.popup.one("open",this._popupOpen.bind(this))},_postCreatePopup:function(){l.fn._postCreatePopup.call(this),this._attachFocusHandlers()},_getElementDataItem:function(e){return e&&e[0]?e[0]===this.optionLabel[0]?this._optionLabelDataItem():this.listView.dataItemByIndex(this.listView.getElementIndex(e)):null},_click:function(t){var i=this,n=t.item||e(t.currentTarget);t.preventDefault(),i.trigger("select",{dataItem:i._getElementDataItem(n),item:n})?i.close():(i._userTriggered=!0,i._select(n).done((function(){i._blur(),i._focusElement(i.wrapper)})))},_focusElement:function(e){var t=p(),i=this.wrapper,n=this.filterInput,o=e===n?i:n,s=r.mobileOS&&(r.touch||r.MSPointers||r.pointers);n&&n[0]===e[0]&&s||n&&(o[0]===t||this._focusFilter)&&(this._focusFilter=!1,this._prevent=!0,this._focused=e.trigger("focus"))},_searchByWord:function(e){if(e){var t=this;t.options.ignoreCase&&(e=e.toLowerCase()),t._select((function(i){return t._matchText(t._text(i),e)}))}},_inputValue:function(){return this.text()},_search:function(){var e=this,t=e.dataSource;if(clearTimeout(e._typingTimeout),e._isFilterEnabled())e._typingTimeout=setTimeout((function(){var t=e.filterInput.val();e._prev!==t&&(e._prev=t,e.search(t),e._resizeFilterInput()),e._typingTimeout=null}),e.options.delay);else{if(e._typingTimeout=setTimeout((function(){e._word=""}),e.options.delay),!e.listView.bound())return void t.fetch().done((function(){e._selectNext()}));e._selectNext()}},_get:function(t){var i,n,o,s="function"==typeof t,a=s?e():e(t);if(this.hasOptionLabel()&&("number"==typeof t?t>-1&&(t-=1):a.hasClass("k-list-optionlabel")&&(t=-1)),s){for(i=this.dataSource.flatView(),o=0;o<i.length;o++)if(t(i[o])){t=o,n=!0;break}n||(t=-1)}return t},_firstItem:function(){this.hasOptionLabel()?this._focus(this.optionLabel):this.listView.focusFirst()},_lastItem:function(){this._resetOptionLabel(),this.listView.focusLast()},_nextItem:function(){var e;return this.optionLabel.hasClass("k-focus")?(this._resetOptionLabel(),this.listView.focusFirst(),e=1):e=this.listView.focusNext(),e},_prevItem:function(){var e;if(!this.optionLabel.hasClass("k-focus"))return e=this.listView.focusPrev(),this.listView.focus()||this.options.virtual||this._focus(this.optionLabel),e},_focusItem:function(){var e=this.options,i=this.listView,n=i.focus(),o=i.select();(o=o[o.length-1])===t&&e.highlightFirst&&!n&&(o=0),o!==t?i.focus(o):!e.optionLabel||e.virtual&&"dataItem"===e.virtual.mapValueTo?i.scrollToIndex(0):(this._focus(this.optionLabel),this._select(this.optionLabel),this.listView.content.scrollTop(0))},_resetOptionLabel:function(e){this.optionLabel.removeClass("k-focus"+(e||"")).removeAttr("id")},_focus:function(e){var i=this.listView,n=this.optionLabel;if(e===t)return!(e=i.focus())&&n.hasClass("k-focus")&&(e=n),e;this._resetOptionLabel(),e=this._get(e),i.focus(e),-1===e&&(n.addClass("k-focus").attr("id",i._optionID),this.filterInput&&this.filterInput.removeAttr("aria-activedescendant").attr("aria-activedescendant",i._optionID))},_select:function(e,t){var i=this;return e=i._get(e),i.listView.select(e).done((function(){t||i._state!==x||(i._state=k),-1===e&&i._selectValue(null)}))},_selectValue:function(e){var i=this,n=i.options.optionLabel,o=i.listView.select(),s="",a="";(o=o[o.length-1])===t&&(o=-1),this._resetOptionLabel(" k-selected"),e||0===e?(a=e,s=i._dataValue(e),n&&(o+=1)):n&&(i._focus(i.optionLabel.addClass("k-selected")),a=i._optionLabelText(),s="string"==typeof n?"":i._value(n),o=0),i.selectedIndex=o,null===s&&(s=""),i._textAccessor(a),i._accessor(s,o),i._triggerCascade()},_mobile:function(){var e=this.popup,t=r.mobileOS;e.element.parents(".km-root").eq(0).length&&t&&(e.options.animation.open.effects=t.android||t.meego?"fadeIn":t.ios||t.wp?"slideIn:up":e.options.animation.open.effects)},_span:function(){var e,t,n=this,o=n.wrapper,a="span.k-input-value-text",l=i.guid(),r=n.options;(e=o.find(a))[0]||(t=s.renderButton('<span role="button" class="k-input-button" aria-label="select"></span>',{icon:"caret-alt-down",size:r.size,fillMode:r.fillMode,shape:"none",rounded:"none"}),o.append('<span id="'+l+'" unselectable="on" class="k-input-inner"><span class="k-input-value-text"></span></span>').append(t).append(n.element),e=o.find(a)),n.span=e,n._arrow=o.find(".k-input-button"),n._arrowIcon=n._arrow.find(".k-icon,.k-svg-icon")},_wrapper:function(){var e,t=this,i=t.element,n=i[0];(e=i.parent()).is("span.k-picker")||((e=i.wrap("<span />").parent())[0].style.cssText=n.style.cssText,e[0].title=n.title),t._focused=t.wrapper=e.addClass("k-picker k-dropdownlist").addClass(n.className).removeClass("input-validation-error").css("display","").attr({accesskey:i.attr("accesskey"),unselectable:"on",role:"combobox","aria-expanded":!1}),i.hide().removeAttr("accesskey")},_clearSelection:function(e){this.select(e.value()?0:-1)},_openHandler:function(e){this._adjustListWidth(),this.trigger("open")?e.preventDefault():(this.wrapper.attr("aria-expanded",!0),this.ul.attr("aria-hidden",!1))},_closeHandler:function(e){this.trigger("close")?e.preventDefault():(this.wrapper.attr("aria-expanded",!1),this.ul.attr("aria-hidden",!0))},_inputTemplate:function(){var e=this,t=e.options.valueTemplate;if(t=t?i.template(t):t=>n(e._text(t)),e.valueTemplate=t,e.hasOptionLabel()&&!e.options.optionLabelTemplate)try{e.valueTemplate(e._optionLabelDataItem())}catch(e){throw new Error("The `optionLabel` option is not valid due to missing fields. Define a custom optionLabel as shown here http://docs.telerik.com/kendo-ui/api/javascript/ui/dropdownlist#configuration-optionLabel")}},_textAccessor:function(i){var n=null,o=this.valueTemplate,s=this._optionLabelText(),a=this.span;if(i===t)return a.text();e.isPlainObject(i)||i instanceof u?n=i:s&&s===i&&(n=this.options.optionLabel),n||(n=this._assignInstance(i,this._accessor())),this.hasOptionLabel()&&(n!==s&&this._text(n)!==s||(o=this.optionLabelTemplate,"string"!=typeof this.options.optionLabel||this.options.optionLabelTemplate||(n=s)));var l=function(){return{elements:a.get(),data:[{dataItem:n}]}};this.angular("cleanup",l);try{a.html(o(n))}catch(e){a.html("")}this.angular("compile",l)},_preselect:function(e,t){e||t||(t=this._optionLabelText()),this._accessor(e),this._textAccessor(t),this._old=this._accessor(),this._oldIndex=this.selectedIndex,this.listView.setValue(e),this._initialIndex=null,this._presetValue=!0},_assignInstance:function(e,t){var i=this.options.dataTextField,n={};return i?(T(n,i.split("."),e),T(n,this.options.dataValueField.split("."),t),n=new u(n)):n=e,n}});function T(e,t,i){for(var n,o=0,s=t.length-1;o<s;++o)(n=t[o])in e||(e[n]={}),e=e[n];e[t[s]]=i}function D(e,t){return e>=t&&(e-=t),e}o.plugin(y),i.cssProperties.registerPrefix("DropDownList","k-picker-"),i.cssProperties.registerValues("DropDownList",[{prop:"rounded",values:i.cssProperties.roundedValues.concat([["full","full"]])}])}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.dropdownlist.js.map
