﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteSheetPacker.SpriteSheetPack;

namespace SpriteSheetPacker.MappingFileFormats {
    /*
        shooter_spritesheet.png
        12
        00 player_1 0 0 16 16
        01 player_1_turn_1 0 16 16 16
        02 player_1_turn_2 0 32 16 16
        03 player_2 16 0 16 16
        04 player_2_turn_1 16 16 16 16
        05 player_2_turn_2 16 32 16 16
        06 enemy_1 194 0 16 16
        07 bullet_1 146 0 16 16
        08 bullet_2 146 16 16 16
        09 explosion_1 0 100 24 24
        10 explosion_2 26 100 24 24
        11 bullet_3 50 100 16 16
     */
    public class EngineFormatFile : IMappingFile {
        public string Extension => ".data";

        private StringBuilder _sb;
        private int _frameCount = 0;
        
        public void AddFrame(string fileName, int x, int y, int width, int height) {
            _sb.AppendFormat("{0} {1} {2} {3} {4} {5} {6}", _frameCount, fileName, x, y, width, height, Environment.NewLine);
            _frameCount++;
        }

        public void AddFrames(FrameList sheet) {
            foreach (var frame in sheet.Frames) {
                AddFrame(frame.FileName, frame.PositionInSheetX, frame.PositionInSheetY, frame.Width, frame.Height);
            }
        }

        public void Start() {
            _sb = new StringBuilder();
        }

        public void End(string fileName, int width, int height) {
            _sb.Insert(0, fileName + Environment.NewLine + _frameCount + Environment.NewLine);
        }

        public string GetFileContent() {
            return _sb.ToString();
        }
    }
}