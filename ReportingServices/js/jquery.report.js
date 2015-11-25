$(document).ready(function () {
	$($("input[value='查看报表']").parents("span")[0]).before("<p id='pquery'></p>")
	$("input[value='查看报表']").appendTo("#pquery")
})