$(function () {
    AjaxCall('/Location/GetCountry', null).done(function (response) {
        if (response.length > 0) {
            $('#countryDropDownList').html('');
            var options = '';
            options += '<option value="Select">Select</option>';
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + response[i].CountryId + '">' + response[i].CountryName + '</option>';
            }
            $('#countryDropDownList').append(options);

        }
    }).fail(function (error) {
        alert(error.StatusText);
    });

    $('#countryDropDownList').on("change", function () {
        var data = $('#countryDropDownList').val();
        var CountryName = { CountryName: data };
        AjaxCall('/Location/EditState', JSON.stringify(CountryName),'POST').done(function (response) {
            if (response.length > 0) {
                $('#stateDropDownList').html('');
                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].StateId + '">' + response[i].StateName + '</option>';
                }
                $('#stateDropDownList').append(options);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

    $('#stateDropDownList').on("change", function () {
        var data = $('#countryDropDownList').val();
        var CountryName = { CountryName: data };
        var data1 = $('#stateDropDownList').val();
        var StateName = { StateName: data1 };
        var Name = { CountryName: data, StateName: data1 };
        AjaxCall('/Location/EditCity', JSON.stringify(Name), 'POST').done(function (response) {
            if (response.length > 0) {
                $('#cityDropDownList').html('');
                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].CityName + '">' + response[i].CityName + '</option>';
                }
                $('#cityDropDownList').append(options);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

});

$("body").on("click", "#btnDelete", function () {
    if (confirm("Do you want to delete this Country?")) {
        var data = $('#countryDropDownList').val();
        var CountryId = { CountryId: data };
        $.ajax({
            type: "POST",
            url: "/Location/Delete",
            data: JSON.stringify(CountryId),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (CountryId) {
                if (CountryId != null) {
                    alert("Country Deleted Sucessfully");
                } else {
                    alert("Country record not found.");
                }
            }
        });

        AjaxCall('/Location/GetCountry', null).done(function (response) {
            if (response.length > 0) {
                $('#countryDropDownList').html('');
                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].CountryId + '">' + response[i].CountryName + '</option>';
                }
                $('#countryDropDownList').append(options);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    }
});

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}  
