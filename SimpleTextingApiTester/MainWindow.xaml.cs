using Newtonsoft.Json;
using SimpleTextingDotNet.v2;
using SimpleTextingDotNet.v2.Model.Object;
using SimpleTextingDotNet.v2.Model.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static SimpleTextingDotNet.Enum;

namespace SimpleTextingApiTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var expansions = new List<string>();
            foreach ( var expansion in Enum.GetNames( typeof( Mode ) ) )
            {
                expansions.Add( expansion );
            }
            lbMode.ItemsSource = expansions;
        }

        /// <summary>
        /// Get an instance of api client.
        /// </summary>
        /// <returns></returns>
        private Client GetApiClient()
        {
            var ApiKey = tbApiKey.Text.Trim();
            var api = new Client( ApiKey );
            return api;
        }

        /// <summary>
        /// Handles the Click event of the Get Message Details button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetMessageDetails_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var response = api.GetMessage( tbMessageId.Text );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Handles the Click event of the Get All Messages button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void GetAllMessages_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var response = api.GetMessages();
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        private void GetContactInfo_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var response = api.GetContact( tbContactId.Text.Trim() );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }

        }

        private void GetAllContacts_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var response = api.GetContacts();
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }

        }

        /// <summary>
        /// Handles the Click event of the Send Message button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SendMessage_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var mediaItemList = tbMediaItems.Text.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ).Select( t => t.Trim() ).ToList();
                Mode selectedMode = Mode.AUTO;
                if ( lbMode.SelectedItem != null )
                {
                    selectedMode = ( Mode ) lbMode.SelectedItem;
                }
                var response = api.SendMessage(
                    tbContactPhone.Text.Trim(),
                    tbText.Text.Trim(),
                    selectedMode,
                    tbAccountPhone.Text.Trim(),
                    tbSubject.Text.Trim(),
                    tbFallbackText.Text.Trim(),
                    mediaItemList );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Handles the Click event of the Create Contact button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CreateContact_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                Client api = GetApiClient();
                var lists = tbLists.Text.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ).Select( t => t.Trim() ).ToList();
                DateTime? birthday = null;
                if ( !string.IsNullOrWhiteSpace( dpBirthday.Text.Trim() ) )
                {
                    birthday = DateTime.Parse( dpBirthday.Text );
                }
                var response = api.CreateContact(
                    tbContactPhoneContact.Text.Trim(),
                    tbFirstName.Text.Trim(),
                    tbLastName.Text.Trim(),
                    tbEmail.Text.Trim(),
                    birthday,
                    tbComment.Text.Trim(),
                    lists );
                DisplayMessageInfo( response );
            }
            catch ( Exception ex )
            {
                DisplayException( ex );
            }
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayMessageInfo( Object response )
        {
            var responseType = response.GetType();
            var hasData = false;
            if ( responseType == typeof( Message ) )
            {
                var message = ( Message ) response;
                if ( message != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( message, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( Contact ) )
            {
                var contactResponse = ( Contact ) response;
                if ( contactResponse != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( contactResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( SendResponse ) )
            {
                var sendResponse = ( SendResponse ) response;
                if ( sendResponse != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( sendResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( ContactResponse ) )
            {
                var contactResponse = ( ContactResponse ) response;
                if ( contactResponse != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( contactResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( MessagesResponse ) )
            {
                var messagesResponse = ( MessagesResponse ) response;
                if ( messagesResponse != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( messagesResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            else if ( responseType == typeof( ContactsResponse ) )
            {
                var contactsResponse = ( ContactsResponse ) response;
                if ( contactsResponse != null )
                {
                    tbResponse.Text = JsonConvert.SerializeObject( contactsResponse, Formatting.Indented );
                    tbResponse.Foreground = Brushes.Green;
                    hasData = true;
                }
            }
            if ( !hasData )
            {
                tbResponse.Text = "Please check your API Key";
                tbResponse.Foreground = Brushes.Red;
                return;
            }
            tbResponse.Focus();
        }

        /// <summary>
        /// Displays the Message information.
        /// </summary>
        private void DisplayException( Exception exception )
        {
            var sb = new StringBuilder();
            sb.AppendLine( exception.Message );
            if ( exception.InnerException != null )
            {
                sb.AppendLine( exception.InnerException.Message );
            }
            tbResponse.Text = sb.ToString();
            tbResponse.Foreground = Brushes.Red;
            tbResponse.Focus();
        }
    }
}
