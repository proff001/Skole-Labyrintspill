﻿using System;

namespace Labyrintspill {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var game = new GameMain())
                game.Run();
        }
    }
}
