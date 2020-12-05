#include "iTunesCOMInterface.h"
#include <iostream>

#define CALL_COM( call ) if ( ( result = call ) != S_OK ) { SetLastError ( result ); return FALSE; }


IiTunes* itunes = nullptr;

BOOL GetCurrentTrack ( IITTrack** track ) {
	HRESULT result;

	CALL_COM ( itunes->get_CurrentTrack ( track ) );
	return TRUE;
}

extern "C" {
	__declspec( dllexport ) BOOL Initialize ( BOOL needsCoInit ) {
		HRESULT result;

		if ( needsCoInit )
			CALL_COM ( CoInitializeEx ( NULL, COINIT_MULTITHREADED ) );

		CALL_COM ( CoCreateInstance ( CLSID_iTunesApp, NULL, CLSCTX_LOCAL_SERVER, IID_IiTunes, (void**) &itunes ) );
		return TRUE;
	}

	__declspec( dllexport ) BOOL UnInitialize ( BOOL needsCoUnInit ) {
		HRESULT result;

		if ( itunes != nullptr )
			CALL_COM ( itunes->Release ( ) );
		if ( needsCoUnInit )
			CoUninitialize ( );

		return TRUE;
	}

	__declspec( dllexport ) BOOL GetCurrentTrackName ( BSTR* buffer ) {
		HRESULT result;
		IITTrack* track;

		if ( !GetCurrentTrack ( &track ) )
			return FALSE;

		CALL_COM ( track->get_Name ( buffer ) );
		CALL_COM ( track->Release ( ) );
		return TRUE;
	}

	__declspec( dllexport ) BOOL GetCurrentTrackAuthor ( BSTR* buffer ) {
		HRESULT result;
		IITTrack* track;

		if ( !GetCurrentTrack ( &track ) )
			return FALSE;

		CALL_COM ( track->get_Artist ( buffer ) );
		CALL_COM ( track->Release ( ) );
		return TRUE;
	}

	__declspec( dllexport ) BOOL GetCurrentTrackAlbum ( BSTR* buffer ) {
		HRESULT result;
		IITTrack* track;

		if ( !GetCurrentTrack ( &track ) )
			return FALSE;

		CALL_COM ( track->get_Album ( buffer ) );
		CALL_COM ( track->Release ( ) );
		return TRUE;
	}

	__declspec( dllexport ) BOOL GetCurrentTrackLength ( long* buffer ) {
		HRESULT result;
		IITTrack* track;

		if ( !GetCurrentTrack ( &track ) )
			return FALSE;

		CALL_COM ( track->get_Duration ( buffer ) );
		CALL_COM ( track->Release ( ) );
		return TRUE;
	}

	__declspec( dllexport ) BOOL GetCurrentPosition ( long* buffer ) {
		HRESULT result;

		CALL_COM ( itunes->get_PlayerPosition ( buffer ) );
		return TRUE;
	}
}