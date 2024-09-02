﻿let datatable;
$(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#table_complementos').DataTable({
        language: {
            lengthMenu: "Mostrar _MENU_ registros por página",
            zeroRecords: "No hay registros disponibles.",
            info: "Pág. _PAGE_ de _PAGES_ - Mostrando del _START_ al _END_ de _TOTAL_ registros",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtrado de un total _MAX_ registros)",
            loadingRecords: "Cargando en curso...",
            emptyTable: "No hay registros disponibles.",
            search: "Buscar",
            paginate: {
                first: "Primero",
                last: "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        ajax: {
            url: "/Complementos/ListarTodos"
        },
        columns: [
            {
                data: "complementoId",
                render: function (data) {
                    return `
                        <a href="/Complementos/Edit/${data}" class="btn btn-sm btn-success text-white" style="cursor:pointer;">
                            <i class="bi bi-pencil-square"></i>
                        </a>
                        <a href="/Complementos/Detail/${data}" class="btn btn-sm btn-info text-white" style="cursor:pointer;">
                            <i class="bi bi-list-task"></i>
                        </a>
                        <a onclick=Delete("/Complementos/Delete/${data}") class="btn btn-sm btn-danger text-white" style="cursor:pointer;">
                            <i class="bi bi-trash3-fill"></i>
                        </a>
                    `;
                }, width: "30%", orderable: false, searchable: false, className: "text-center"
            },
            { data: "name", className: "text-center" },
            { data: "descripcion", className: "text-center" },
            { data: "costo_gramo", width: "10%", className: "text-center" },
            { data: "categoria.nombre", className: "text-center" },
            { data: "receta.name", className: "text-center" },

        ]
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de eliminar el complemento?",
        text: "Este registro no se podrá recuperar",
        html: true,
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url, // Publishers/Delete/5
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload(); // Recargar el datatable
                    }
                    else {
                        toastr.error(data.message); // Notificaciones
                    }
                },
            });
        }
    });
}