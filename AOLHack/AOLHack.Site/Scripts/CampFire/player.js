﻿var CampFire = {
    InitPlayer : function() {
        var player = new PlayerSeed('player1');
        player.playList = '518034012';
        player.sid = 577;
        player.width = 700;
        player.height = 400;
        player.autoStart = true;
        player.Load();

        return player;
    }
};