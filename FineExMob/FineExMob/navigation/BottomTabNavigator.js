import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import * as React from 'react';

import TabBarIcon from '../components/TabBarIcon';
import ProfileScreen from '../screens/ProfileScreen';
import CompanyScreen from '../screens/CompanyScreen';
import DocumentsScreen from '../screens/DocumentsScreen';
import StatisticsScreen from '../screens/StatisticsScreen';

const BottomTab = createBottomTabNavigator();
const INITIAL_ROUTE_NAME = 'Profile';

export default function BottomTabNavigator({ navigation, route }) {
  // Set the header title on the parent stack navigator depending on the
  // currently active tab. Learn more in the documentation:
  // https://reactnavigation.org/docs/en/screen-options-resolution.html
  navigation.setOptions({ headerTitle: getHeaderTitle(route) });

  return (
    <BottomTab.Navigator initialRouteName={INITIAL_ROUTE_NAME}>
      <BottomTab.Screen
        name="Profile"
        component={ProfileScreen}
        options={{
          title: 'Profile',
          tabBarIcon: ({ focused }) => <TabBarIcon focused={focused} name="ios-person" />,
        }}
      >
      </BottomTab.Screen>
      <BottomTab.Screen
        name="Company"
        component={CompanyScreen}
        options={{
          title: 'Company',
          tabBarIcon: ({ focused }) => <TabBarIcon focused={focused} name="ios-business" />,
        }}
      />
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
