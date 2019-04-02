namespace Mapbox.Examples.Playground
{
	using Mapbox.Unity;
	using System;
	using UnityEngine;
	using UnityEngine.UI;
	using Mapbox.Json;
	using Mapbox.Directions;
	using Mapbox.Utils;
	using Mapbox.Utils.JsonConverters;
	using Mapbox.Geocoding;
	using Mapbox.Unity.Map;

	/// <summary>
	/// Fetch directions JSON once start and end locations are provided.
	/// Example: Enter Start Location: San Francisco, Enter Destination: Los Angeles
	/// </summary>
	public class DirectionsGeoCoder : MonoBehaviour
	{
		public GameObject DirectionsPrefabStart;
		public GameObject DirectionsPrefabEnd;
		public AbstractMap _map;
		//public Text textDebug;
		private bool Routing;
		private Vector2d StartLoc;
		private Vector2d EndLoc;

		[SerializeField]
		ForwardGeocodeUserInput _startLocationGeocoder;

		[SerializeField]
		ForwardGeocodeUserInput _endLocationGeocoder;

		Directions _directions;

		Vector2d[] _coordinates;

		DirectionResource _directionResource;

		void Start()
		{
			_directions = MapboxAccess.Instance.Directions;
			_startLocationGeocoder.OnGeocoderResponse += StartLocationGeocoder_OnGeocoderResponse;
			_endLocationGeocoder.OnGeocoderResponse += EndLocationGeocoder_OnGeocoderResponse;

			_coordinates = new Vector2d[2];

			// Can we make routing profiles an enum?
			_directionResource = new DirectionResource(_coordinates, RoutingProfile.Driving);
			_directionResource.Steps = true;
			Routing = false;
		}

		public void ClearRoute()
		{
			if(ShouldRoute())
			{
				Routing = false;
			}
			Destroy(GameObject.Find("direction waypoint entity"));
			Destroy(GameObject.Find("GPSendpos(Clone)"));
			Destroy(GameObject.Find("GPSstartpos(Clone)"));
		}

		void Update()
		{
			StartLoc = _startLocationGeocoder.Coordinate;
			EndLoc = _endLocationGeocoder.Coordinate;
			if(ShouldRoute())
			{
				Routing = true;
			}
			if(!GameObject.Find("GPSstartpos(Clone)"))
			{
				if(Routing)
				{
					var instance = Instantiate(DirectionsPrefabStart);
					instance.transform.localPosition = _map.GeoToWorldPosition(StartLoc, true);
					//textDebug.text = "Spawned start";
				}
			}
			if(!GameObject.Find("GPSendpos(Clone)"))
			{
				if(Routing)
				{
					var instance = Instantiate(DirectionsPrefabEnd);
					instance.transform.localPosition = _map.GeoToWorldPosition(EndLoc, true);
					//textDebug.text = "Spawned end";
				}
			}
			if(GameObject.Find("GPSstartpos(Clone)") & GameObject.Find("GPSendpos(Clone)"))
			{
				Routing = false;
			}
			if(!GameObject.Find("GPSstartpos(Clone)") & !GameObject.Find("GPSendpos(Clone)"))
			{
				Destroy(GameObject.Find("direction waypoint entity"));
			}

		}

		void OnDestroy()
		{
			if (_startLocationGeocoder != null)
			{
				_startLocationGeocoder.OnGeocoderResponse -= StartLocationGeocoder_OnGeocoderResponse;
			}

			if (_startLocationGeocoder != null)
			{
				_startLocationGeocoder.OnGeocoderResponse -= EndLocationGeocoder_OnGeocoderResponse;
			}
		}

		/// <summary>
		/// Start location geocoder responded, update start coordinates.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void StartLocationGeocoder_OnGeocoderResponse(ForwardGeocodeResponse response)
		{
			_coordinates[0] = _startLocationGeocoder.Coordinate;
			Destroy(GameObject.Find("GPSstartpos(Clone)"));
		}

		/// <summary>
		/// End location geocoder responded, update end coordinates.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void EndLocationGeocoder_OnGeocoderResponse(ForwardGeocodeResponse response)
		{
			_coordinates[1] = _endLocationGeocoder.Coordinate;
			Destroy(GameObject.Find("GPSendpos(Clone)"));
		}

		/// <summary>
		/// Ensure both forward geocoders have a response, which grants access to their respective coordinates.
		/// </summary>
		/// <returns><c>true</c>, if both forward geocoders have a response, <c>false</c> otherwise.</returns>
		bool ShouldRoute()
		{
			return _startLocationGeocoder.HasResponse && _endLocationGeocoder.HasResponse;
		}

		/// <summary>
		/// Route 
		/// </summary>
		void Route()
		{
			_directionResource.Coordinates = _coordinates;
			_directions.Query(_directionResource, HandleDirectionsResponse);
		}
		/// <summary>
		/// Log directions response to UI.
		/// </summary>
		/// <param name="res">Res.</param>
		void HandleDirectionsResponse(DirectionsResponse res)
		{
				//spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
				//spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
		}
	}
	
}