$("document").ready(
    function () {
        $("#Filter").click(
            function () {
                let uri = `http://localhost:5041/${window.UsingController}/GetProductCatalog/?`;
                if (this.hasAttribute("data-StoreID")) {
                    let ext = "StoreID=" + this.getAttribute("data-StoreID");
                    uri = uri + ext;
                }
                if (this.hasAttribute("data-BrandID")) {
                    let ext = "BrandID=" + this.getAttribute("data-BrandID");
                    uri = uri + ext;
                }
                if (this.hasAttribute("data-StoreTypeID")) {
                    let ext = "StoreTypeID=" + this.getAttribute("data-StoreTypeID");
                    uri = uri + ext;
                }
                $.ajax({
                    url: uri,
                    method: "GET",
                    dataType: "html",
                    beforeSend: function () {
                        let loader = "<div class='modal-inner' style='top: 40 %; right: 40 %; position: calc(-50 %, -50 %); position: absolute'>" +
                            "<img src='~/GUI/images/AJAX_GIF.gif'/>" +
                            "</div>";
                        $("#dataBar").html(loader);
                    },
                    error: function () {
                        // your code here;
                    },
                    success: function (data) {
                        setTimeout(function () {
                            $("#dataBar").html(data);
                            reapplyDynamicStyles();
                        }, 3000);
                    },
                    complete: function () {
                        // your code here;
                    }
                });
            }
        );
    });