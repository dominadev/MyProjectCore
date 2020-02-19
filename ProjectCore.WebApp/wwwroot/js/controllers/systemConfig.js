(function (window, $) {
    window.systemConfig = {
        table: $("#datatable"),
        columnTable: [
            {
                field: 'Key',
                title: 'Mã',
                align: 'left',
                valign: 'middle',
                searchable: true,
                sortable: true
            },
            {
                field: 'Value',
                title: 'Value',
                align: 'left',
                valign: 'middle',
                searchable: false,
                sortable: false
            },
            
            {
                field: 'Description',
                title: 'Mô tả',
                align: 'left',
                valign: 'middle',
                searchable: false,
                sortable: false
            },
        ],
        init: function () {
            
            systemConfig.createTable();
        },
        createTable: function () {
            systemConfig.table.bootstrapTable({
                url: "/SystemConfig/GetListSystemConfig",
                method: "POST",
                ajax: function (config) {
                    console.log("start", config);
                    $.ajax({
                        type: "POST",
                        url: config.url,
                        data: config.data,
                        success: function (rs) {
                            console.log(rs);
                            if (rs.Status == 1) {
                                config.success({
                                    total: rs.TotalRow,
                                    rows: rs.Data
                                });
                            }
                            else {

                             
                            }
                        }
                    });
                },
                striped: true,
                sidePagination: 'server',
                pagination: true,
                paginationVAlign: 'both',
                limit: 10,
                pageSize: 10,
                pageList: [10, 25, 50, 100, 200],
                search: true,
                showColumns: true,
                showRefresh: true,
                columns: systemConfig.columnTable,
                searchOnEnterKey: true,
                queryParamsType:'notLimit'
            })
        }
    }

})(window, jQuery);

$(document).ready(function () {
    systemConfig.init();
});