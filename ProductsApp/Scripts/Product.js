var script = document.createElement('script');
script.src = 'Scripts/jquery-2.2.3.js';
script.type = 'text/javascript';
document.getElementsByTagName('head')[0].appendChild(script);

function GetAllProducts() {
    $.ajax({
        url: 'http://localhost:47503/api/product/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        beforeSend: function () {
            // setting a timeout
            $("#loading").show();
        },
        complete: function () {
            $('#loading').hide();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function AddProduct() {
    var product = {
        Id: $('#txtId').val(),
        Name: $('#txtName').val(),
        Price: $('#txtPrice').val(),
        isActive: $("#chkIsActive").prop('checked')
    };

    if ((product.Id == "") && (product.Name == "")) {
        $("#divResult").html("Input code and name");
        $('#txtId').focus();
        window.scrollTo(0, document.body.scrollHeight);
    }
    else
    {

        $.ajax({
            url: 'http://localhost:47503/api/product/',
            type: 'POST',
            data: JSON.stringify(product),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                WriteResponse(data);
            },
            beforeSend: function () {
                // setting a timeout
                $("#loading").show()
            },
            complete: function () {
                $('#loading').hide();
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }
}

function WriteResponse(products) {
    var strResult = "<table><th>ID</th><th>Name</th><th>Price</th><th>Active</th>";
    $.each(products, function (index, product) {
        strResult += "<tr><td>" + product.Id + "</td><td> " + product.Name + "</td><td>" + product.Price + "</td><td>" + product.isActive + "</td></tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);
    window.scrollTo(0, document.body.scrollHeight);
}

function ShowProduct(product) {
    if (product != null) {
        var strResult = "<table><th>ID</th><th>Name</th><th>Price</th><th>Active</th>";
        strResult += "<tr><td>" + product.Id + "</td><td> " + product.Name + "</td><td>" + product.Price + "</td><td>" + product.isActive + "</td></tr>";
        strResult += "</table>";
        $("#divResult").html(strResult);
    }
    else
    {
        $("#divResult").html("No Results To Display");
    }
    window.scrollTo(0, document.body.scrollHeight);
}

function GetProduct() {
    var id = $('#txtFindId').val();
    if (id != "") {
        $.ajax({
            url: 'http://localhost:47503/api/product/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                ShowProduct(data);
            },
            beforeSend: function () {
                // setting a timeout
                $("#loading").show();
            },
            complete: function () {
                $('#loading').hide();
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }
    else
    {
        $("#divResult").html("Input some code");
        $('#txtFindId').focus();
        window.scrollTo(0, document.body.scrollHeight);
    }
}