namespace Udokotela.Model
{
    /// <summary>
    /// Classe de modèle pour l'entité utilisateur
    /// </summary>
    public class User
    {
        #region properties

        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Photo de profil de l'utilisateur
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        /// Rôle de l'utilisateur
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Etat de connexion de l'utlisateur
        /// </summary>
        public bool Connected { get; set; }
    
        #endregion
    }
}