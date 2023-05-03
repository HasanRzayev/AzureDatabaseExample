$(document).ready(function () {
    $("#CategoryList").change(function () {
        var categoryId = $(this).val();
        $.ajax({
            type: "GET",
            url: "@Url.Action("GetProductsByCategoryId", "Product")",
            data: { categoryId: categoryId },
            success: function (data) {
                // Ürünlerin listelendiği yer
                console.log(data)
                $("#productList").html(data);
            },
            error: function () {
                alert("Bir hata oluştu!");
            }
        });
    });
});
