import * as Linking from 'expo-linking';

export default {
  prefixes: [Linking.makeUrl('/')],
  config: {
    Root: {
      path: 'root',
      screens: {
        Login: 'login',
        Profile: 'profile',
        Company: 'company',
        Documents: 'documents',
        Statistics: 'statistics'
      },
    },
  },
};
