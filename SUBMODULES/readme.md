## Development Directions ##

Note that Visual Studio 2022 has a constraint that it only lists Repos that contain Visual Studio 
*solution file (*.sln)-based* repositories, and does not recognise *folder-based* solutions.

This in effect means that changes within `BASE.Documentation` -- which is a *folder-based* set of *.md files -- will not be made apparent
in visual studio.

One can hope this be resolved in a later version of Visual Studio -- but there is no certainty of this. 


## Modules ##

This folder references Repos of *logical* module extensions to the host.

The first one is a *Template* module, that is used to clone and develop additional logical *Modules*.

The Logical Modules of a system are:

- *`Sys`[tem]*, managing infrastructure,logging, etc.
- *`Users`*: system users
- *`Persons`*
- *[PersonIdentity]`Groups`*: adhoc and official groups.
- *`Resources`*: records to manage media used by the system.



## Development Directions ##
Adding a git repo as a submodule is straightforwards, whereas removing is a little bit trickier, as per below.

### Adding a Git Submodule ###

* From the repo's root directory;
  * Using TortoiseGit: 
    * On File Explorer's advanced context menu:
      * Select `Submodule Add...`
	    * Enter the repo to clone as a submodule (e.g.: `https://github.com/skysgh/BASE.Modules.Template`)
		* enter the target path (e.g.: `SUBMODULES/BASE.Modules.Template`)
  * Using the command line:
    * git submodule add https://github.com/skysgh/BASE.Modules.Template SUBMODULES/BASE.Modules.Template
	* This:
      *	adds a repo under `SUBMODULES/`
	  * adds an entry within `.git/config`
	  * adds a repo under `.git/modules`
	

### Removing a Submodule ###
* From the repo's root directory:
  * Using TortoiseGit:
    * DAMN: There is no option to do it.
  * Using the command line:
    * `git rm <path-to-submodule>`
	  * e.g.: `git rm SUBMODULES/Base.Modules.Template`
	* `rm -rf .git/modules/<path-to-submodule>`
	* `git config --remove-section submodule.<path-to-submodule>`
