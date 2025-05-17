$("document").ready(
    function () {
        $(".Filter").click(
            function () {;
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
                if (this.hasAttribute("data-SaleID")) {
                    let ext = "SaleID=" + this.getAttribute("data-SaleID");
                    uri = uri + ext;
                }
                alert(uri);
                $.ajax({
                    url: uri,
                    method: "GET",
                    dataType: "html",
                    beforeSend: function () {
                        let loader = `<div class="modal-inner"" style="top: 40 %; right: 40 %; position: absolute; transform: translate(-50%, -50%)">` +
                            `<img src="~/GUI/images/AJAX_GIF.gif" style="top: 40%;left: 50%; position: absolute; transform: translate(-50%, -50%)"/>` +
                            `</div>`;
                        $(".ProductContent").html(loader);
                    },
                    error: function () {
                        // your code here;
                    },
                    success: function (data) {
                        alert(data);
                        setTimeout(function () {
                            $(".ProductContent").html(data);
                        }, 3000);
                    },
                    complete: function () {
                        // your code here;
                    }
                });
            }
        );
    });