var CampFire = {
    InitPlayer : function(videoId) {
        var player = new PlayerSeed('player1');
        player.playList = videoId;
        player.sid = 577;
        player.width = 1024;
        player.height = 576;
        player.autoStart = true;
        player.playerActions = 16391;
        player.Load();

        return player;
    },

    PlayNext: function () {
        jQuery.post('/home/playnext', {}, function (data) {
            debugger;
            //var player = new PlayerSeed('player1');
            //player.playlistChangeVideo(data.videoId, "", "");
            FIVEMIN.OnePlayer.Data.get().Players[0].flashObj.playlistChangeVideo(data.videoId, "", "");
        },"json");
    }
};
