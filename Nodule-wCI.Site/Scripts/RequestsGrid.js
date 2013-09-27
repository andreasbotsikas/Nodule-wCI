Nodule = window.Nodule || {};
Nodule.RequestGrid = function (divId, statusUrl, buildLogUrl, restartUrl, odataRequestUrl) {
    $("#" + divId ).kendoGrid({
        pageable: {
            pageSizes: [15, 50, 100, 150]
        },
        filterable: true,
        sortable: true,
        scrollable: false,
        columns: [
            { field: "Id", hidden: true },
            {
                field: "RepoUrl",
                title: "Repository",
                template: function(dataItem) {
                    return '<a href="' + dataItem.RepoUrl + '" target="_blank">' + dataItem.RepoUrl + "</a><span class='subtle'> (" + dataItem.PullRequestReference + ')</span>';
                }
            },
            {
                field: "Date",
                format: "{0:dd/MM/yyyy}",
                width: "110px"
            },
            {
                field: "StatusId",
                title: "Status",
                template: function(dataItem) {
                    return '<img src="' + statusUrl + dataItem.Id + '"/>';
                }
            },
            {
                title: "",
                width: "110px",
                template: function(dataItem) {
                    return "<ul class='row-menu'><li>Actions<ul>" +
                        "<li><a href='" + buildLogUrl + dataItem.Id + "'>Build log</a></li>" +
                        "<li><a href='" + restartUrl + dataItem.Id + "'>Restart build</a></li>" +
                        "</ul></li></ul>";
                }
            }
        ],
        dataBound: function() {
            // Make menu items
            $(".row-menu").kendoMenu();
            $('.row-menu').closest("td").addClass("menu-cell");
        },
        selectable: false,
        dataSource: {
            type: "odata",
            serverPaging: true,
            pageSize: 15,
            serverFiltering: true,
            serverSorting: true,
            sort: { field: "Date", dir: "desc" },
            transport: {
                read: {
                    url: odataRequestUrl,
                    dataType: "json"
                }
            },
            // describe the result format
            schema: {
                // the data which the data source will be bound to is a PageResult class, so Items and Count
                data: "Items",
                total: "Count",
                model: {
                    fields: {
                        Date: { type: "date" }
                    }
                }
            }
        },
    });

};