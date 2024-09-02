﻿let datatable;
$(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#table_users').DataTable({
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
            url: "/AppUsers/ListarTodos"
        },
        columns: [
            {
                data: "id",
                render: function (data) {
                    return `
                        <a href="#" class="btn btn-sm btn-info text-white" style="cursor:pointer;">
                            <i class="bi bi-people-fill">Roles</i>
                        </a>
                    `;
                }, width: "10%", orderable: false, searchable: false, className: "text-center"
            },
            {
                data: "lockoutEnabled",
                render: function (data) {
                    if (data == true) {
                        return `<span class="btn btn-sm btn-danger"><i class="bi bi-lock-fill"></i></span>`;
                    } else {
                        return `<span class="btn btn-sm btn-success"><i class="bi bi-unlock-fill"></i></span>`;
                    }
                }, width: "10%", orderable: false, searchable: false, className: "text-center"
            },
            {
                data: {
                    firstName: "firstName", lastName: "lastName"
                },
                render: function(data){ return data.lastName + ' ' + data.firstName; }
            },
            { data: "email" },
            { data: "phoneNumber" },
            { data: "role"},
            {
                data: "lockoutEnabled",
                render: function (data) {
                    if (data == true) {
                        return `<span class="badge rounded-pill bg-info">ACTIVO</span>`;
                    } else {
                        return `<span class="badge rounded-pill bg-warning">INACTIVO</span>`;
                    }
                }, width: "10%", orderable: false, searchable: false, className: "text-center"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de eliminar el autor?",
        text: "Este registro no se podrá recuperar",
        html: true,
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url, // Authors/Delete/5
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload(); // Recargar el datatable
                    }
                    else {
                        toastr.error(data.message); // Notificaciones
                    }
                }
            });
        }
    });
}