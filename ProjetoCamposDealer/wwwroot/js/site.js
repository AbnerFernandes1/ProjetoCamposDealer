function confirmDelete() {
    var result = confirm("Deseja realmente deletar essa venda?");
    if (result) {
        document.getElementById("deleteForm").submit();
    }
}