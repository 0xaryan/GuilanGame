﻿using GuilanGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuilanGame.Configurations
{
    public partial class Configuration
    {

        [XmlIgnore]
        public string IgnoredProperty { get; set; }

        public double MusicPlayerVolume { get; set; } = 1;
        public double EffectPlayerVolume { get; set; } = 1;

        public ObservableCollection<RecordItem> RecordData { get; set; } = new ObservableCollection<RecordItem>();

    }
}
