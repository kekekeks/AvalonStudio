﻿using Avalonia.Media;
using AvalonStudio.MVVM;
using AvalonStudio.Projects;
using System;

namespace AvalonStudio.Controls.Standard.SolutionExplorer
{
    public abstract class SolutionItemViewModel : ViewModel
    {
        public abstract DrawingGroup Icon { get; }

        public static SolutionItemViewModel Create(SolutionViewModel solutionViewModel, ISolutionItem item)
        {
            SolutionItemViewModel result = null;

            if (item is ISolutionFolder folder)
            {
                result = new SolutionFolderViewModel(solutionViewModel, folder);
            }
            else if(item is IProject project)
            {
                result = new StandardProjectViewModel(solutionViewModel, project);
            }
            else
            {
                throw new Exception("Unrecognised model type");
            }

            return result;
        }
    }
}