﻿using Terraria;
using TerrariaApi.Server;
using TShockAPI.Hooks;


namespace MiniGamesAPI
{
    [ApiVersion(2, 1)]
    public class MiniGamesAPI : TerrariaPlugin
    {
        #region 插件模版信息
        public override string Name => "MiniGamesAPI";
        public override string Author => "豆沙 羽学修复";
        public override Version Version => new Version(1, 0, 8);
        public override string Description => "小游戏框架API";
        #endregion

        #region 注册与释放
        public MiniGamesAPI(Main game) : base(game) { }
        public override void Initialize()
        {
            ServerApi.Hooks.GamePostUpdate.Register((TerrariaPlugin)(object)this, (HookHandler<EventArgs>)OnPostUpdate);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.GamePostUpdate.Deregister((TerrariaPlugin)(object)this, (HookHandler<EventArgs>)OnPostUpdate);
            }
            base.Dispose(disposing);
        }
        public static int GameTick;
        #endregion

        private void OnPostUpdate(EventArgs args)
        {
            GameTick++;
            if ((GameTick %= 60) != 0)
            {
                Task.Run(delegate
                {
                });
            }
        }

    }
}