function callAjax(method, url, data, successCallbackFn, errorCallbackFn, bAsync = true, dataType = 'json') {
    try {
        $.ajax({
            type: method,
            url: url,
            cache: false,
            //contentType: 'application/json',
            data: data,
            dataType: dataType,
            async: bAsync,
            success: function (response) {
                if (successCallbackFn && response) {
                    successCallbackFn(response);
                }
            },
            error: function (exception) {
                if (errorCallbackFn) {
                    errorCallbackFn(exception);
                }
            }
        });
    }
    catch (exception) {
    }
}