var CampFire = {
    InitPlayer : function() {
        var player = new PlayerSeed('player1');
        player.playList = '518034012';
        player.sid = 577;
        player.width = 1024;
        player.height = 576;
        player.autoStart = true;
        player.playerActions = 16391;
        player.Load();

        return player;
    }
};