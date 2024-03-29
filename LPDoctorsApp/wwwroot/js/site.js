﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


var ready;

ready = function () {

    function alignmentByHeight(classname) {
        var divs = $("div ." + classname);
        var max = 100;
        for (var i = 0; i < divs.length; i++) {
            if (max < $(divs[i]).height()) {
                max = $(divs[i]).height();
            }
        }
        $(divs).css('min-height', max + 'px');
    }

    $(document).ready(function () {

        alignmentByHeight('cl-about .live-scroll-box');
        alignmentByHeight('service');
        alignmentByHeight('social-proof-sameheight');

    });

};

$(document).ready(ready);

$(document).on('page:load', ready);
