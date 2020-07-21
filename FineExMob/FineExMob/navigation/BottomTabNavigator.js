import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import * as React from 'react';

import TabBarIcon from '../components/TabBarIcon';
import ProfileScreen from '../screens/ProfileScreen';
import CompanyScreen from '../screens/CompanyScreen';
import DocumentsScreen from '../screens/DocumentsScreen';
import StatisticsScreen from '../screens/StatisticsScreen';

const BottomTab = createBottomTabNavigator();
const INITIAL_ROUTE_NAME = 'Profile';

function getHeaderTitle(route) {
  const routeName = route.state?.routes[route.state.index]?.name ?? INITIAL_ROUTE_NAME;

  switch (routeName) {
    case 'Profile':
      return 'Profile'
    case 'Company':
      return 'Company'
    case 'Documents':
      return 'Documents'
    case 'Statistics':
      return 'Statistics'
  }
}

export default class BottomTabNavigator extends React.Component {

  render() {
    const { navigation, route, ...stateProps } = this.props;

    navigation.setOptions({ headerTitle: getHeaderTitle(route) });

    return (
      <BottomTab.Navigator initialRouteName={INITIAL_ROUTE_NAME}>
        <BottomTab.Screen
          name="Profile"
          options={{
            title: 'Profile',
            tabBarIcon: ({ focused }) => <TabBarIcon focused={focused} name="ios-person" />,
          }}
        >
          {(bottomTabProps) => <ProfileScreen {...bottomTabProps} {...stateProps} />}
        </BottomTab.Screen>
        <BottomTab.Screen
          name="Company"
          options={{
            title: 'Company',
            tabBarIcon: ({ focused }) => <TabBarIcon focused={focused} name="ios-business" />,
          }}
        >
          {(bottomTabProps) => <CompanyScreen {...bottomTabProps} {...stateProps} />}
        </BottomTab.Screen>
        <BottomTab.Screen
          name="Documents"
          component={DocumentsScreen}
          options={{
            title: 'Documents',
            tabBarIcon: ({ focused }) => <TabBarIcon focused={focused} name="ios-paper" />,
          }}
        />
        <BottomTab.Screen
          name="Statistics"
          component={StatisticsScreen}
          options={{
            title: 'Statistics',
            tabBarIcon: ({ focused }) => <TabBarIcon focused={focused} name="md-calculator" />,
          }}
        />
      </BottomTab.Navigator>
    );
  }
};
