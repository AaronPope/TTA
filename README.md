# Tabletop Assistant TTA
Xamarin reboot of a Counter app that was abandonded a couple of years ago.

## Background
This is a "pet project" that originated from a desire to have a convenient, portable means of keeping score for tabletop games.
In particular, it originally replaced the scorekeeping cards for Star Realms.
Small card games, like Star Realms, oftentimes implement "creative" ways to track scores in such a way that requires minimum table space.
Unfortunately, they can also be pretty clunky and relatively fragile -- prone to an accidental (or "accidental") shift of the table.

## Approach
This app eliminates those physical problems, while simultaneously placing scorekeeping functionality onto devices that are always at-the-ready.
I chose Xamarin because it is a mature platform for cross-platform mobile development, and C# is my opinionated preference over Java.
I have devices that run on either Android or iOS, but I generally always have my Android device around.
As such, during the course of development, I will first focus on making Android views and utilize default iOS views. 
As time allows, I will circle back to better utilize iOS views.


## Development Status & Goals
The overall goal of this app is to expand it to cover a wide range of scoring mechanisms.

But for now, it does the following:
* Creation or removal of multilple players
* +1 or -1 incrementing of scores
* Preview of score change, requiring confirmation to commit
* Renaming of players


Future development may include, but is not limited to:
* Saving sessions
* Keeping play history
* Specialized scoring modules for individual games
* UI color modification by user
* Logging plays to [Board Game Geek](boardgamegeek.com)
* Creating linked local sessions, for individuals to track their own score & share it to all session members

## Misc
There are some extraneous files in this repo.  The come from the Xamarin template used to bootstrap the project.
I'm leaving them in because I believe that they may be useful for future development.
