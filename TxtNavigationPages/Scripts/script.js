/// <reference path="jquery-3.1.0.js" />

function pageLoad(pageNumber, stringsPerBlock, blocksPerPage) {
    $.get("../api/pages",
        {
        	"blocksPerPage": blocksPerPage,
			"stringsPerBlock": stringsPerBlock,
			"pageNumber": pageNumber
        }, onPageRecieved);
}

function onPageRecieved(data) {
    var blocksSection = $("section#blocks");
    blocksSection.empty();

    var newBlocks = data.Blocks;
    for (var i = 0; i < newBlocks.length; i++) {
    	var div = $("<div></div>");

        for (var j = 0; j < newBlocks[i].Strings.length; j++) {
            div.append($("<div></div>").text(newBlocks[i].Strings[j]));
        }
        blocksSection.append(div);
        blocksSection.append($("<hr />"));
    }
}

function reloadPageWithViewParameters() {
	var stringsPerBlock = $("#stringsPerBlock").val();
	var blocksPerPage = $("#blocksPerPage").val();
	var newUrl = "../home/viewtext?stringsPerBlock=" + stringsPerBlock + "&blocksPerPage=" + blocksPerPage;
	//window.location.replace(newUrl);
	window.location.href = newUrl;
}