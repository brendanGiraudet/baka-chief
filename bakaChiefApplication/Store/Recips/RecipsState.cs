﻿using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    [FeatureState]
    public class RecipsState
    {
        public bool IsLoading { get; }

        public bool IsRecipFormHidden { get; }

        public IEnumerable<Models.Recip> Recips { get; }
        
        public Models.Recip Recip { get; }

        private RecipsState() { }

        public RecipsState(bool? isLoading = null, IEnumerable<Models.Recip>? recips = null, bool? isRecipFormHidden = null, Models.Recip? recip = null)
        {
            IsLoading = isLoading ?? false;
            Recips = recips ?? Enumerable.Empty<Models.Recip>();
            IsRecipFormHidden = isRecipFormHidden ?? true;
            Recip = recip ?? new();
        }
    }
}
