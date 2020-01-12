This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).
npx create-react-app my-app --template typescript

## Code Challenge
The solution you create must be able to be installed on an environment running node and npm, following the readme.md file you create.
No external dependencies should be required outside of the files listed in your solution and the api given.
Tech Challenge Instructions:
•	You have up to 2 hours to complete this challenge
•	Create a stand-alone react application that renders on a single html page
•	Create a readme.md file with clear instructions on how to install and run your app.
•	Demonstrate the use of appropriate css techniques to style your app
You can use a boiler plate (create-react-app) or setup your own build system (be mindful of the time limit)

### Application requirements
1.	Request data from and display the next 5 races from this API -
https://s3-ap-southeast-2.amazonaws.com/bet-easy-code-challenge/next-to-jump
2.	Ensure the data displayed is kept up to date as the information may change over time
3.	Add these required fields to your UI view
Event Name, Event Venue, Time the event starts, iconography (see https://s3-ap-southeast-2.amazonaws.com/bet-easy-code-challenge/design-sample.png)
4.	Add styling to reflect the BetEasy Brand (www.beteasy.com.au)
5.	Create unit tests as required to verify your application works and explain why you have written tests

### Bonus Points:
1.	Create a way for users to filter races by type
2.	Add error handling to handle error response codes from the API

### Unit Test
* More test cases can be introduced
* Code covergae can be reached to 100% or minimum 90% for production

### Further Enhancements 

* Refer Comments added while code commit in git at https://github.com/SatishJaiswalOZ/fullstack-reactjs-dotnetcore-apps/commits/0fa3b054a0e1f269de85c5d531b37d987cfd230b/bet-easy-react-app
* Usage or Suspense, Memo, Common framework for UI re-usable elements
* CSS Specificity 
* Usage of SASS or LESS i.e. node-sass
* Code Split 
* Accessibility
* Cross Browser & Responsiveness
* API call fetch only 5 items but if backend supports more then 5 items needs to be restricted at frontend
* Best Practices for Production readiness
* * https://create-react-app.dev/docs/production-build/
* * https://reactjs.org/docs/optimizing-performance.html


## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.<br />
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.<br />
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.<br />
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.<br />
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.<br />
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can’t go back!**

If you aren’t satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (Webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you’re on your own.

You don’t have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn’t feel obligated to use this feature. However we understand that this tool wouldn’t be useful if you couldn’t customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).
