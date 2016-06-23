/// <reference path="../ckfinder/ckfinder.html" />
/// <reference path="../ckfinder/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config in web address : http://docs.ckeditor.com/#!/api/CKEDITOR.config

    
    config.syntaxhighlight_lang = 'Csharp';
    config.syntaxhighlight_hidecontrols = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Content/admin/plugin/ckfinder/ckfinder.html';
    config.filebrowserFlashBrowseUrl = '/Content/admin/plugin/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserFlashUploadUrl = '/Content/admin/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash',
    config.filebrowserImageBrowseUrl = '/Content/admin/plugin/ckfinder/ckfinder.html?type=Images';
    config.filebrowserImageUploadUrl = '/data';
    config.filebrowserUploadUrl = '/Content/admin/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';   
        
    CKFinder.setupCKEditor(null, '/Content/admin/plugin/ckfinder/')

};
