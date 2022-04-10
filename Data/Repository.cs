namespace Data
{
    internal class Repository
    {
        private Context context;

        public Repository(IInitialiser initialiser)
        {
            context = new Context(initialiser.InitialiseBooks(), initialiser.InitialiseUsers(), 
                      initialiser.InitialiseStates(), initialiser.InitialiseEvents());
        }
        internal Context Context => context;
    }
}
