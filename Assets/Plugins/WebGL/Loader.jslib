var Loader = {
    GameLoaded: function()
    {
        doGameLoadedStuff();
    }
};

mergeInto(LibraryManager.library, Loader);