var poppy = poppy || {};

(function (poppy) {
    'use strict';

    var Popups = (function () {
        var TIMEOUT = 4000;

        var Popup = function (title, message, type, position, autoHide, timeout, closeButton, callback) {
            this._popupData = {};
            this._popupData.title = title;
            this._popupData.message = message;
            this._popupData.type = type;
            this._popupData.position = position;
            this._popupData.autoHide = autoHide;
            this._popupData.timeout = timeout;
            this._popupData.closeButton = closeButton;
            this._popupData.callback = callback;
        }

        var Success = function(title, message) {
            this.prototype = Object.create(Popup.prototype);
            this.prototype.constructor = Popup;

            Popup.call(this, title, message, 'success', 'bottomLeft', true, TIMEOUT, false, undefined);
        }

        var Info = function (title, message) {
            this.prototype = Object.create(Popup.prototype);
            this.prototype.constructor = Popup;

            Popup.call(this, title, message, 'info', 'topLeft', false, 0, true, undefined);
        }

        var Error = function (title, message) {
            this.prototype = Object.create(Popup.prototype);
            this.prototype.constructor = Popup;

            Popup.call(this, title, message, 'error', 'topRight', true, TIMEOUT, false, undefined);
        }

        var Warning = function (title, message, callback) {
            this.prototype = Object.create(Popup.prototype);
            this.prototype.constructor = Popup;

            Popup.call(this, title, message, 'warning', 'bottomRight', false, 0, false, callback);
        }

        return {
            Success: Success,
            Info: Info,
            Error: Error,
            Warning: Warning
        }
    })();

    poppy._data = {
        Popups: Popups
    }
})(poppy);