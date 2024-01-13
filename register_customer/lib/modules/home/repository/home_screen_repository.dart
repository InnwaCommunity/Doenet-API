import 'package:register_customer/services/api_service.dart';

abstract class HomeScreenRepository {
  Future<dynamic> fetchClusterLists(String userId);
  Future<dynamic> createCluster(String clusterName,String password,bool isUsePas,String userId);
  Future<dynamic> validateClusterPassword(String userId,String clusterIdval,String password);
}

class HomeScreenRepositoryImpl extends HomeScreenRepository {
  ApiService apiService = ApiService();
  @override
  Future fetchClusterLists(String userId) {
    Map<String, dynamic> requestBody = {'UserId': userId};
    return apiService.post('api/Cluster/GetClusterList', requestBody);
  }


  @override
  Future createCluster(String clusterName,String password,bool isUsePas,String userId){
    Map<String,dynamic> requestBody={
      'ClusterName': clusterName,
      'IsPasswordUse': isUsePas,
      'Password': password,
      'CreatorIdval': userId
    };
    return apiService.post('api/Cluster/CreateCluster', requestBody);
  }

  @override
  Future validateClusterPassword(String userId,String clusterIdval,String password) {
    Map<String, dynamic> requestBody = {
      'UserId': userId,
      'ClusterIdval': clusterIdval,
      'Password':password
      };
    return apiService.post('api/Cluster/ValidateClusterPassword', requestBody);
  }
}
