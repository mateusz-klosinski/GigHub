var FollowsController = function(followService) {
    var button;

    var init = function() {
        $(".js-toggle-follow")
            .click(toggleFollow);
    };

    var toggleFollow = function(e) {
        button = $(e.target);

        var artistName = button.attr("data-artist-name");

        if (button.hasClass("btn-default"))
            followService.createFollow(artistName, done, fail);
        else
            followService.deleteFollow(artistName, done, fail);

    };

    var done = function () {
        var text = (button.text() == "Following") ? "Follow?" : "Following"; 

        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function() {
        alert("Something failed");
    };


    return {
        init: init
    };

}(FollowService);