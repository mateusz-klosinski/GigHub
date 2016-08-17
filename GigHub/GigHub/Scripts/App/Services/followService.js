var FollowService = function() {

    var createFollow = function(artistName, done, fail) {
        $.post("/api/follows", { ArtistName: artistName })
            .done(done)
            .fail(fail);
    };

    var deleteFollow = function(artistName, done, fail) {
        $.ajax(
            {
                url: "/api/follows",
                method: "DELETE",
                data: { ArtistName: artistName }
            })
            .done(done)
            .fail(fail);
    };

    return {
        createFollow: createFollow,
        deleteFollow: deleteFollow
    };
}();