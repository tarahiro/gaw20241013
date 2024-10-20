using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gad20241013.Talk;
using gad20241013.Enemy;
using gad20241013.Item;
using gad20241013.ItemSelector;
using gad20241013.Telop;
using gad20241013.SceneFader;
using Tarahiro;
using Tarahiro.MasterData;


namespace gad20241013.Injection
{
    public class SceneStarter : MonoBehaviour
    {
        public void Start()
        {

            //必要なインスタンスを生成
            var itemMasterDataProvider = new ItemMasterDataProvider();
            var itemProvider = new ItemProvider(itemMasterDataProvider);

            var itemMenu = new ItemMenu();
            var talkManager = new TalkManager();
            var doctor = new Doctor();
            var sceneFader = new SceneFader.SceneFader();
            var ItemSelector = new ItemSelector.ItemSelector(itemMenu,itemProvider);
            var clearTelop = new ClearTelop();
            var endingTelop = new EndingTelop();
            var openingFactory = new OpeningFactory(talkManager, sceneFader, doctor);
            var cycleFactory = new CycleFactory(talkManager,ItemSelector,itemProvider,clearTelop,doctor);
            var endingFactory = new EndingFactory(talkManager, sceneFader, endingTelop, doctor);
            var gameManager = new GameManager(openingFactory, cycleFactory,endingFactory);

            //GameManager起動
            gameManager.Main().Forget();
        }
    }
}