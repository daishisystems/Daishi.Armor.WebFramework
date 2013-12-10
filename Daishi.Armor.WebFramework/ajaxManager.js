var ajaxManager = ajaxManager || {
    setHeader: function(armorToken) {
        $.ajaxSetup({
            beforeSend: function(xhr, settings) {
                if (settings.type !== "GET") {
                    xhr.setRequestHeader("Authorization", "ARMOR " + armorToken);
                }
            }
        });
    }
};