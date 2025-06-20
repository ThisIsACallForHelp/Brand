$("document").ready(
    function () {
        $(".Filter").click(
            function () {
                let Sale = document.getElementById("SaleID").value;
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
                if (Sale > 0) {
                    uri += "SaleID=" + Sale;
                }
                alert(uri);
                $.ajax({
                    url: uri,
                    method: "GET",
                    dataType: "html",
                    beforeSend: function () {
                        let loader = `<style>
                                        .parent
                                         {
                                            height:100%;
                                            text-align:center;
                                            margin:auto;
                                            padding-top: 100px;
                                         }
                                        .child
                                        {
                                            height:750px;
                                            width:750px;
                                            margin-right: 100px;
                                            padding: 0px;
                                        }
                                      </style>
                                      <div class=parent>
                                        <div class='child'>
                                            <img src='/GUI/images/AJAX_GIF.gif' alt='ajax ajax' style='width:750px; height:750px;'/>
                                        </div>
                                      </div>`;
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