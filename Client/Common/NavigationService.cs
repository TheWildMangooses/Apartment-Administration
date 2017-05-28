﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace Client.Common
{
    public class NavigationService
    {
        /// <summary>
        /// This holds the instance to the Only NavigationService in this app.
        /// </summary>
        public static NavigationService Instance { get; protected set; }

        /// <summary>
        /// This will hold the reference to the frame that is to be manipulated.
        /// </summary>
        private Frame frame;

        /// <summary>
        /// The Stack of pages to enable Stack based Navigation.
        /// </summary>
        public Stack<Type> PageStack { get; protected set; }

        #region CTOR
        /// <summary>
        /// The default constructor to instantiate this class with reference to a frame
        /// </summary>
        /// <param name="frame">The referenced frame</param>
        public NavigationService(ref Frame frame)
        {
            //Check is the instance doesnt already exist.
            if (Instance != null)
            {
                //if there is an instance in the app already present then simply throw an error.
                throw new Exception("Only one navigation service can exist in a App.");
            }
            //setting the instance to the static instance field.
            Instance = this;
            //setting the frame reference.
            this.frame = frame;
            //intialising the stack.
            this.PageStack = new Stack<Type>();
        }
        #endregion
        #region Navigation Methods
        public void NavigateTo(Type pageType, object parameter)
        {
            if (PageStack.Count > 0)
            {
                if (PageStack.Peek() == pageType)
                    return;
            }
            PageStack.Push(pageType);
            frame.Navigate(pageType, parameter);
        }

        public void NavigateBack()
        {
            if (frame.CanGoBack)
                frame.GoBack();
            PageStack.Pop();
        }

        public void NavigateToHome()
        {
            while (frame.CanGoBack)
                frame.GoBack();
        }
        #endregion
    }
}
