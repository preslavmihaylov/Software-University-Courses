/* 
 * <!--
 *  This work contains portions from toastr js library
 *  - https://github.com/CodeSeven/toastr
 *  under the MIT license
 *  - http://www.opensource.org/licenses/mit-license.php
 *  -->
 */

var poppy = poppy || {};

(function (poppy) {
    'use strict';

    var FADE_DELAY = 50;

    function pop(type, title, message, callback) {
        var popup;
        switch (type) {
            case 'success':
                popup = new poppy._data.Popups.Success(title, message);
                break;
            case 'info':
                popup = new poppy._data.Popups.Info(title, message);
                break;
            case 'error':
                popup = new poppy._data.Popups.Error(title, message);
                break;
            case 'warning':
                popup = new poppy._data.Popups.Warning(title, message, callback);
                break;
            default:
                throw new Error('Invalid popup type');
                break;
        }

        // generate view from the view factory
        var view = poppy._viewFactory.createPopupView(popup);

        processPopup(view, popup);
    }

    function processPopup(domView, popup) {
        if (popup._popupData.closeButton) {
            domView.childNodes[0].childNodes[0].onclick = function () {
                removeElement(domView, 1);
            }
        }

        if (popup._popupData.callback) {
            domView.onclick = popup._popupData.callback;
        }

        domView.style.opacity = 0;
        document.body.appendChild(domView);

        insertElement(domView, popup, FADE_DELAY);
    }

    function insertElement(domElement, popup, timeout) {
        var currentOpacity = 0.1;

        var fadeInTimer = setInterval(function () {
            fadeElement(domElement, currentOpacity);
            currentOpacity += 0.1;
            if (currentOpacity >= 1) {
                window.clearInterval(fadeInTimer);

                if (popup._popupData.autoHide) {
                    removeElement(domElement, popup._popupData.timeout);
                }
            }
        }, timeout);
    }

    function removeElement(domElement, timeout) {
        var FADEOUT_DELAY = 50,
            currentOpacity = 1;

        var timeoutTimer = setInterval(function () {
            var fadeOutTimer = setInterval(function () {
                fadeElement(domElement, currentOpacity);

                currentOpacity -= 0.1;
                if (currentOpacity <= 0) {
                    document.body.removeChild(domElement);
                    window.clearInterval(fadeOutTimer);
                }
            }, FADEOUT_DELAY);

            window.clearInterval(timeoutTimer);

        }, timeout);
    }

    function fadeElement(domView, opacity) {
        domView.style.opacity = opacity;
    }

    poppy.pop = pop;
})(poppy);